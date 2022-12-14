//=============================================================================
// Copyright ? 2011 Point Grey Research, Inc. All Rights Reserved.
//
// This software is the confidential and proprietary information of Point
// Grey Research, Inc. ("Confidential Information").  You shall not
// disclose such Confidential Information and shall use it only in
// accordance with the terms of the license agreement you entered into
// with PGR.
//
// PGR MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF THE
// SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE, OR NON-INFRINGEMENT. PGR SHALL NOT BE LIABLE FOR ANY DAMAGES
// SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING
// THIS SOFTWARE OR ITS DERIVATIVES.
//=============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlyCapture2Managed;

namespace FlyCap2CameraControl
{
    /* If you can not open the design view of this class, try to modify base class
     * to "UserControl" instead of "BasePage". VS2005 probably has issue of opening 
     * design view for inherited user control. The reason is still investigating.
     * */

     //public partial class LadybugSettingsPage : UserControl
    internal partial class LadybugSettingsPage : BasePage
    {
        // Register definitions
        // 0x80000001 (1%) -> 0x80000064 (100%)
        // Bit7 = 1 indicating auto jpeg is enabled
        private const uint CompressorJpegQualityReg = 0x1a20;

        // The least significant byte is the buffer usage for JPEG compression
        // 0x......01 (1%) -> 0x......FF (100%)
        private const uint Compressor_BufferControlReg = 0x1a24;

        // Register 1e80h updates similar functionality found in 1a20h.
        // For Ladybug2, valid since firmware 1.0.2.0 and later
        // For Ladtbug3, valid since firmware 1.2.2.1 and later
        private const uint JpegControlReg = 0x1e80;

        // Register 1e84h and 1E88h update similar functionality found in 1a24h.
        // For Ladybug2, valid since firmware 1.0.2.0 and later
        // For Ladtbug3, valid since firmware 1.2.2.1 and later
        private const uint JpegBufferUsageReg = 0x1e84;
        private const uint ImageSelectionReg = 0x1e88; 

        // Ladybug3 only
        private const uint AE_Stats_MaskReg = 0x1e90;
        private LadybugPropertyControl[] m_independentSensorControls = new LadybugPropertyControl[3];
        private CheckBox[] m_sensorForStatCheckBoxes = new CheckBox[6];

        private bool m_isLadybug = false;

        private Timer m_updateTimer = new Timer();
        
        public LadybugSettingsPage(ManagedCameraBase initialCamera)
        {
            SetCamera(initialCamera);
            InitializeComponent();
            InitializePage();
        }

        private void OnTimer(Object o, EventArgs eventArgs)
        {
            if (m_camera == null || m_isLadybug == false)
            {
                return;
            }

            if (m_isPageSelected)
            {
                UpdateJpegSettingsValues();
                UpdateIndependentSensorControls();
                UpdateSensorForStatsSettings();
            }
        }

        private void InitializePage()
        {
            Debug.Assert(m_camera != null, "Unable to initialize ladybug setting page. The current camera is null.");
            if (m_camera == null)
            {
                //Bad!
                m_mainGroupBox.Enabled = false;
                return;
            }   

            m_isLadybug = IsLadybugModel();

            InitializeControls();                                 
            
            if (!m_isLadybug)
            {
                m_compressionControlPanel.Enabled = false;
                m_independentSensorControlPanel.Enabled = false;
                m_sensorUsedForAutoExposureStaticsControlPanel.Enabled = false;
                return;
            }

            InitializeAutoUsageBufferValue();
            InitializeJpegQualityValue();
            OnAutoQualityCheckedChanged(this, null); // Use this handler to update corresponding controls related to checkboxes
            UpdateIndependentSensorControls();
            InitializeSensorForStatValue();

            m_updateTimer.Tick += new EventHandler(OnTimer);
            m_updateTimer.Interval = 100;
            m_updateTimer.Start();
        }

        private void InitializeSensorForStatValue()
        {
            //Set sensor-for-statistics control
            bool isSensorForStatsSupported = false;
            uint uiRegVal = 0;
            if (IsLadybug3() || IsLadybug5())
            {
                try
                {
                    uiRegVal = m_camera.ReadRegister(AE_Stats_MaskReg);
                }
                catch (FC2Exception ex)
                {
                    ShowErrorMessageDialog("Error reading auto exposure statistics register", ex);
                }

                isSensorForStatsSupported = (uiRegVal & 0x80000000) > 0;
            }

            m_sensorAutStatControlPanel.Enabled = isSensorForStatsSupported;
        }

        private void InitializeJpegQualityValue()
        {
            uint uiRegVal = 0;
            try
            {
                uiRegVal = m_camera.ReadRegister(JpegControlReg);
                if ((uiRegVal & 0x80000000) == 0)
                {
                    // JPEG control feature is not supported
                    m_jpegQualityTrackbar.Enabled = false;
                    m_jpegQualityTrackbarValue.Enabled = false;
                    m_jpegAutoQualityCheckBox.Enabled = false;
                }
                else
                {
                    m_jpegQualityTrackbar.Enabled = true;
                    m_jpegQualityTrackbarValue.Enabled = true;
                    m_jpegAutoQualityCheckBox.Enabled = true;
                }

                if ((uiRegVal & 0x01000000) != 0)
                {
                    m_jpegAutoQualityCheckBox.Checked = true;
                }
                else
                {
                    m_jpegAutoQualityCheckBox.Checked = false;
                }

                if ((uiRegVal & 0x000000FF) == 0)
                {
                    // The default is 60% in Firmware if the value is 0
                    m_jpegQualityTrackbar.Value = 600;
                }
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG control register", ex);
            }
        }

        private void InitializeAutoUsageBufferValue()
        {
            uint uiRegVal = 0;
            try
            {
                uiRegVal = m_camera.ReadRegister(JpegBufferUsageReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG control register", ex);
            }

            if ((uiRegVal & 0x80000000) == 0)
            {
                m_autoBufferUsageTrackbar.Enabled = false;
                m_autoBufferUsageTrackbarValue.Enabled = false;
            }

            // Deal with default value 0
            if ((uiRegVal & 0x0000007F) == 0)
            {
                // TODO: need to make sure if Ladybug5 works in the same way as Ladybug3.
                if (IsLadybug3() || IsLadybug5())
                {
                    // The default is 90% in LD3 Firmware if the value is 0 
                    m_autoBufferUsageTrackbar.Value = 900;
                }
                else
                {
                    // The default is 80% in Firmware if the value is 0
                    m_autoBufferUsageTrackbar.Value = 800;
                }
            }
        }

        private void InitializeControls()
        {            
            LadybugPropertyControl.LadybugType ladybugType;
            if (IsLadybug2())
            {
                ladybugType = LadybugPropertyControl.LadybugType.Ladybug2;
            }
            else if (IsLadybug3())
            {
                ladybugType = LadybugPropertyControl.LadybugType.Ladybug3;
            }
            else if (IsLadybug5())
            {
                ladybugType = LadybugPropertyControl.LadybugType.Ladybug5;
            }
            else
            {
                ladybugType = LadybugPropertyControl.LadybugType.None;
            }

            m_independentSensorControls[0] = new LadybugPropertyControl(m_camera, PropertyType.AutoExposure, ladybugType);
            m_independentSensorControls[0].Dock = DockStyle.Fill;
            m_independentSensorControls[1] = new LadybugPropertyControl(m_camera, PropertyType.Shutter, ladybugType);
            m_independentSensorControls[1].Dock = DockStyle.Fill;
            m_independentSensorControls[2] = new LadybugPropertyControl(m_camera, PropertyType.Gain, ladybugType);
            m_independentSensorControls[2].Dock = DockStyle.Fill;
            m_autoExposureControlPanel.Controls.Add(m_independentSensorControls[0]);
            m_shutterControlPanel.Controls.Add(m_independentSensorControls[1]);
            m_gainControlPanel.Controls.Add(m_independentSensorControls[2]);

            //set a boundary for shutter control panel and gain control panel
            //you can not directly set this value in the design view. That is a bug in VS2005
            m_shutterAndGainControlPanel.Panel2MinSize = 280;
            m_shutterAndGainControlPanel.Panel1MinSize = 280;

            //Initialize sensor-for-statistics control
            for (int i = 0; i < m_sensorForStatCheckBoxes.Length; i++)
            {
                m_sensorForStatCheckBoxes[i] = new CheckBox();
                m_sensorForStatCheckBoxes[i].Tag = i;
                m_sensorForStatCheckBoxes[i].AutoCheck = true;
                m_sensorForStatCheckBoxes[i].CheckedChanged += new EventHandler(OnSensorForStatsCheckedChanged);
                m_sensorAutStatControlPanel.Controls.Add(m_sensorForStatCheckBoxes[i], i, 1);
            }
        }

        private void UpdateIndependentSensorControls()
        {
            for (int i = 0; i < m_independentSensorControls.Length; i++)
            {
                m_independentSensorControls[i].Refresh();
            }
        }
       
        private void OnJpegQualityTrackbar_ValueChanged(object sender, EventArgs e)
        {
            m_jpegQualityTrackbarValue.Text = string.Format("{0:0.0}", (float)m_jpegQualityTrackbar.Value / 10.0f);
        }

        private void OnAutoBufferUsageTrackbar_ValueChanged(object sender, EventArgs e)
        {
            m_autoBufferUsageTrackbarValue.Text = string.Format("{0:0.0}", (float)m_autoBufferUsageTrackbar.Value / 10.0f);
        }

        private void OnSensorForStatsCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int cameraIdx = (int)checkBox.Tag;
            uint regVal = 0;
            uint uiValue = 0;
            try
            {
                regVal = m_camera.ReadRegister(AE_Stats_MaskReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading auto exposure statistics register", ex);
                return;
            }

            uint bitMask = (uint)(0x01 << (m_sensorForStatCheckBoxes.Length - cameraIdx - 1));
            if (checkBox.Checked)
            {
                uiValue = regVal | bitMask;
            }
            else
            {
                uiValue = regVal & (~bitMask);
            }

            try
            {
                m_camera.WriteRegister(AE_Stats_MaskReg, uiValue);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error writing auto exposure statistics register", ex);
                return;
            }
        }

        private void UpdateJpegSettingsValues()
        {
            UpdateJpegAutoBufferUsage();
            UpdateJpegQuality();
        }

        private void UpdateJpegQuality()
        {
            uint uiRegVal = 0;

            try
            {
                uiRegVal = m_camera.ReadRegister(JpegControlReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG control register", ex);
                return;
            }

            if ((uiRegVal & 0x01000000) != 0)
            {
                m_jpegAutoQualityCheckBox.Checked = true;
            }
            else
            {
                m_jpegAutoQualityCheckBox.Checked = false;
            }

            if ((uiRegVal & 0x000000FF) == 0)
            {
                // The default is 60% in Firmware if the value is 0
                m_jpegQualityTrackbar.Value = 600;
            }
            else
            {
                try
                {
                    m_jpegQualityTrackbar.Value = (int)(uiRegVal & 0x000000FF) * 10;
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine("Jpeg quality trackbar value is out of range." + ex.Message);
                }
            }
        }

        private void UpdateJpegAutoBufferUsage()
        {
            uint uiRegVal = 0;
            try
            {
                uiRegVal = m_camera.ReadRegister(JpegBufferUsageReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG buffer usage register", ex);
                return;
            }

            if ((uiRegVal & 0x0000007F) == 0)
            {
                // TODO: need to make sure if Ladybug5 works in the same way as Ladybug3.
                if (IsLadybug3() || IsLadybug5())
                {
                    // The default is 90% in LD3 Firmware if the value is 0 
                    m_autoBufferUsageTrackbar.Value = 900;
                }
                else
                {
                    m_autoBufferUsageTrackbar.Value = 800;
                }
            }
            else
            {
                int trackbarValue = (int)(1000.0 * (double)(uiRegVal & 0x0000007F) / 127.0);
                if (trackbarValue < m_autoBufferUsageTrackbar.Minimum)
                {
                    trackbarValue = m_autoBufferUsageTrackbar.Minimum;
                }

                try
                {
                    m_autoBufferUsageTrackbar.Value = trackbarValue;
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine("Auto Buffer Usage Trackbar value is out of range." + ex.Message);
                }
            }
        }

        private void UpdateSensorForStatsSettings()
        {
            if (m_sensorAutStatControlPanel.Enabled == false)
            {
                // If disabled, do nothing.
                return;
            }

            uint uiRegVal = 0;
            try
            {
                uiRegVal = m_camera.ReadRegister(AE_Stats_MaskReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading auto exposure statistics register", ex);
                return;
            }

            for (int i = 0; i < m_sensorForStatCheckBoxes.Length; i++)
            {
                bool isChecked = ((0x01 << (m_sensorForStatCheckBoxes.Length - i - 1)) & uiRegVal) != 0;
                m_sensorForStatCheckBoxes[i].Checked = isChecked;
            }          
        }

        private void OnJpegQualityTrackbar_Scroll(object sender, EventArgs e)
        {
            uint valueSet = (uint)m_jpegQualityTrackbar.Value / 10;
            uint valueReg = 0;
            try
            {
                valueReg = m_camera.ReadRegister(JpegControlReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG control register.", ex);
                return;
            }

            uint value = (valueReg & 0xFFFFFF00) + (valueSet & 0x000000FF);
            try
            {
                m_camera.WriteRegister(JpegControlReg, value);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error writing JPEG control register.", ex);
                return;
            }
        }

        private void OnAutoBufferUsageTrackbar_Scroll(object sender, EventArgs e)
        {
            uint valueSet = (uint)(((double)m_autoBufferUsageTrackbar.Value * 127.0) / 1000.0);

            // Auto buffer usage definition: 0% - 0x00, 100 - 0xFF
            uint valueReg = 0;
            try
            {
                valueReg = m_camera.ReadRegister(JpegBufferUsageReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG buffer usage register.", ex);
                return;
            }

            uint value = (valueReg & 0xFFFFFF80) + (valueSet & 0x0000007F);
            try
            {
                m_camera.WriteRegister(JpegBufferUsageReg, value);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error writing JPEG buffer usage register", ex);
                return;
            }
        }

        private void OnAutoQualityCheckedChanged(object sender, EventArgs e)
        {
            uint value;
            try
            {
                value = m_camera.ReadRegister(JpegControlReg);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error reading JPEG control register", ex);
                return;
            }

            if (m_jpegAutoQualityCheckBox.Checked == true)
            {
                value |= 0x01000000;
                m_jpegQualityTrackbar.Enabled = false;
                m_jpegQualityTrackbarValue.Enabled = false;
                m_autoBufferUsageTrackbar.Enabled = true;
                m_autoBufferUsageTrackbarValue.Enabled = true;
            }
            else
            {
                value &= 0xFEFFFFFF;
                m_jpegQualityTrackbar.Enabled = true;
                m_jpegQualityTrackbarValue.Enabled = true;
                m_autoBufferUsageTrackbar.Enabled = false;
                m_autoBufferUsageTrackbarValue.Enabled = false;
            }

            try
            {
                m_camera.WriteRegister(JpegControlReg, value);
            }
            catch (FC2Exception ex)
            {
                ShowErrorMessageDialog("Error writing JPEG control register", ex);
                return;
            }
        }
    }
}
