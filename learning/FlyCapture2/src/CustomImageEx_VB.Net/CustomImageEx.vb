'=============================================================================
' Copyright ? 2011 Point Grey Research, Inc. All Rights Reserved.
'
' This software is the confidential and proprietary information of Point
' Grey Research, Inc. ("Confidential Information").  You shall not
' disclose such Confidential Information and shall use it only in
' accordance with the terms of the license agreement you entered into
' with PGR.
'
' PGR MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF THE
' SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
' PURPOSE, OR NON-INFRINGEMENT. PGR SHALL NOT BE LIABLE FOR ANY DAMAGES
' SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING
' THIS SOFTWARE OR ITS DERIVATIVES.
'=============================================================================

Imports System
Imports System.Text
Imports System.IO
Imports System.Drawing
Imports FlyCapture2Managed


Namespace CustomImageEx_VB
    Class Program

        Shared Sub PrintBuildInfo()
            Dim version As FC2Version = ManagedUtilities.libraryVersion
            Dim newStr As StringBuilder = New StringBuilder()
            newStr.AppendFormat("FlyCapture2 library version: {0}.{1}.{2}.{3}" & vbNewLine, _
                                version.major, version.minor, version.type, version.build)
            Console.WriteLine(newStr)
        End Sub


        Shared Sub PrintCameraInfo(ByVal camInfo As CameraInfo)

            Dim newStr As StringBuilder = New StringBuilder()
            newStr.Append(vbNewLine & "*** CAMERA INFORMATION ***" & vbNewLine)
            newStr.AppendFormat("Serial number - {0}" & vbNewLine, camInfo.serialNumber)
            newStr.AppendFormat("Camera model - {0}" & vbNewLine, camInfo.modelName)
            newStr.AppendFormat("Camera vendor - {0}" & vbNewLine, camInfo.vendorName)
            newStr.AppendFormat("Sensor - {0}" & vbNewLine, camInfo.sensorInfo)
            newStr.AppendFormat("Resolution - {0}" & vbNewLine, camInfo.sensorResolution)

            Console.WriteLine(newStr)
        End Sub


        Shared Sub PrintFormat7Capabilities(ByVal fmt7Info As Format7Info)
            Dim newStr As StringBuilder = New StringBuilder()
            newStr.AppendFormat("Max image pixels: ({0}, {1})" & vbNewLine, fmt7Info.maxWidth, fmt7Info.maxHeight)
            newStr.AppendFormat("Image Unit size: ({0}, {1})" & vbNewLine, fmt7Info.imageHStepSize, fmt7Info.imageVStepSize)
            newStr.AppendFormat("Offset Unit size: ({0}, {1})", fmt7Info.offsetHStepSize, fmt7Info.offsetVStepSize)

            Console.WriteLine(newStr)
        End Sub

        Shared Sub Main()
            PrintBuildInfo()

            Const k_fmt7Mode As Mode = Mode.Mode0
            Const k_fmt7PixelFormat As PixelFormat = PixelFormat.PixelFormatMono8
            Const k_numImages As Int32 = 10

            ' Since this application saves images in the current folder
            ' we must ensure that we have permission to write to this folder.
            ' If we do not have permission, fail right away.
            Dim fileStream As FileStream

            Try
                fileStream = New FileStream("test.txt", FileMode.Create)
                fileStream.Close()
                File.Delete("test.txt")
            Catch ex As Exception
                Console.WriteLine("Failed to create file in current folder.  Please check permissions.\n")
                Return
            End Try

            Dim busMgr As ManagedBusManager = New ManagedBusManager()
            Dim numCameras As UInt32 = busMgr.GetNumOfCameras()

            Console.WriteLine("Number of cameras detected: {0}", numCameras)

            Dim guid As ManagedPGRGuid = busMgr.GetCameraFromIndex(0)

            Dim cam As ManagedCamera = New ManagedCamera()

            cam.Connect(guid)

            ' Get the camera information
            Dim camInfo As CameraInfo = cam.GetCameraInfo()

            PrintCameraInfo(camInfo)

            ' Query for available Format 7 modes
            Dim supported As Boolean = False
            Dim fmt7Info As Format7Info = cam.GetFormat7Info(k_fmt7Mode, supported)

            PrintFormat7Capabilities(fmt7Info)

            If ((k_fmt7PixelFormat And fmt7Info.pixelFormatBitField) = 0) Then
                ' Pixel format not supported!
                Console.WriteLine("Pixel format is not supported")
                Return
            End If

            Dim fmt7ImageSettings As Format7ImageSettings = New Format7ImageSettings()
            fmt7ImageSettings.mode = k_fmt7Mode
            fmt7ImageSettings.offsetX = 0
            fmt7ImageSettings.offsetY = 0
            fmt7ImageSettings.width = fmt7Info.maxWidth
            fmt7ImageSettings.height = fmt7Info.maxHeight
            fmt7ImageSettings.pixelFormat = k_fmt7PixelFormat

            ' Validate the settings to make sure that they are valid
            Dim settingsValid As Boolean = False
            Dim fmt7PacketInfo As Format7PacketInfo = cam.ValidateFormat7Settings(fmt7ImageSettings, settingsValid)

            If (settingsValid <> True) Then
                ' Settings are not valid
                Return
            End If


            ' Set the settings to the camera
            cam.SetFormat7Configuration(fmt7ImageSettings, fmt7PacketInfo.recommendedBytesPerPacket)

            ' Get embedded image info from camera
            Dim embeddedInfo As EmbeddedImageInfo = cam.GetEmbeddedImageInfo()

            ' Enable timestamp collection	
            If (embeddedInfo.timestamp.available = True) Then
                embeddedInfo.timestamp.onOff = True
            End If

            ' Set embedded image info to camera
            cam.SetEmbeddedImageInfo(embeddedInfo)

            ' Start capturing images
            cam.StartCapture()

            ' Retrieve frame rate property
            Dim frmRate As CameraProperty = cam.GetProperty(PropertyType.FrameRate)

            Console.WriteLine("Frame rate is {0:F2} fps", frmRate.absValue)

            Console.WriteLine("Grabbing {0} images", k_numImages)

            Dim rawImage As ManagedImage = New ManagedImage()

            For imageCnt As Integer = 0 To (k_numImages - 1)
                ' Retrieve an image
                cam.RetrieveBuffer(rawImage)

                ' Get the timestamp
                Dim timestamp As TimeStamp = rawImage.timeStamp

                Console.WriteLine( _
                   "Grabbed image {0} - {1} {2} {3}", _
                   imageCnt, _
                   timestamp.cycleSeconds, _
                   timestamp.cycleCount, _
                   timestamp.cycleOffset)

                ' Create a converted image
                Dim convertedImage As ManagedImage = New ManagedImage()

                ' Convert the raw image
                rawImage.Convert(PixelFormat.PixelFormatBgr, convertedImage)

                ' Create a unique filename
                Dim filename As String = String.Format( _
                       "CustomImageEx_CSharp-{0}-{1}.bmp", _
                       camInfo.serialNumber, _
                       imageCnt)

                ' Get the Bitmap object. Bitmaps are only valid if the
                ' pixel format of the ManagedImage is RGB or RGBU.

                Dim bitmap As Bitmap = convertedImage.bitmap

                ' Save the image
                bitmap.Save(filename)
            Next

            ' Stop capturing images
            cam.StopCapture()

            ' Disconnect the camera
            cam.Disconnect()

            Console.WriteLine("Done! Press any key to exit...")
            Console.ReadKey()
        End Sub

    End Class
End Namespace

