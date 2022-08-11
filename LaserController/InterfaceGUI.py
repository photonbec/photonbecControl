# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'InterfaceGUI.ui'
#
# Created by: PyQt5 UI code generator 5.15.4
#
# WARNING: Any manual changes made to this file will be lost when pyuic5 is
# run again.  Do not edit this file unless you know what you are doing.


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(240, 320)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.groupBox = QtWidgets.QGroupBox(self.centralwidget)
        self.groupBox.setGeometry(QtCore.QRect(0, 0, 241, 181))
        self.groupBox.setObjectName("groupBox")
        self.powerSlider = QtWidgets.QSlider(self.groupBox)
        self.powerSlider.setGeometry(QtCore.QRect(0, 150, 141, 29))
        self.powerSlider.setMaximum(2400)
        self.powerSlider.setOrientation(QtCore.Qt.Horizontal)
        self.powerSlider.setObjectName("powerSlider")
        self.enable_checkBox = QtWidgets.QCheckBox(self.groupBox)
        self.enable_checkBox.setGeometry(QtCore.QRect(80, 0, 101, 22))
        self.enable_checkBox.setObjectName("enable_checkBox")
        self.label_2 = QtWidgets.QLabel(self.groupBox)
        self.label_2.setGeometry(QtCore.QRect(0, 50, 101, 17))
        self.label_2.setObjectName("label_2")
        self.label_3 = QtWidgets.QLabel(self.groupBox)
        self.label_3.setGeometry(QtCore.QRect(189, 50, 51, 20))
        self.label_3.setObjectName("label_3")
        self.label_4 = QtWidgets.QLabel(self.groupBox)
        self.label_4.setGeometry(QtCore.QRect(190, 100, 31, 20))
        self.label_4.setObjectName("label_4")
        self.label_6 = QtWidgets.QLabel(self.groupBox)
        self.label_6.setGeometry(QtCore.QRect(0, 130, 101, 17))
        self.label_6.setObjectName("label_6")
        self.currentLCD = QtWidgets.QLCDNumber(self.groupBox)
        self.currentLCD.setGeometry(QtCore.QRect(0, 70, 181, 51))
        self.currentLCD.setObjectName("currentLCD")
        self.setLCD = QtWidgets.QLCDNumber(self.groupBox)
        self.setLCD.setGeometry(QtCore.QRect(190, 70, 51, 23))
        self.setLCD.setNumDigits(4)
        self.setLCD.setSegmentStyle(QtWidgets.QLCDNumber.Flat)
        self.setLCD.setObjectName("setLCD")
        self.setText = QtWidgets.QLineEdit(self.groupBox)
        self.setText.setGeometry(QtCore.QRect(160, 150, 51, 27))
        self.setText.setObjectName("setText")
        self.setTextButton = QtWidgets.QPushButton(self.groupBox)
        self.setTextButton.setGeometry(QtCore.QRect(210, 150, 31, 27))
        self.setTextButton.setObjectName("setTextButton")
        self.getPowerPushButton = QtWidgets.QPushButton(self.groupBox)
        self.getPowerPushButton.setGeometry(QtCore.QRect(100, 40, 61, 27))
        self.getPowerPushButton.setObjectName("getPowerPushButton")
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 240, 23))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)
        self.power_timer_checkBox = QtWidgets.QCheckBox(self.groupBox)
        
        self.power_timer_checkBox.setGeometry(QtCore.QRect(155, 0, 101, 22))
        self.power_timer_checkBox.setObjectName("timer_checkBox")


        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.groupBox.setTitle(_translate("MainWindow", "Power"))
        self.enable_checkBox.setText(_translate("MainWindow", "Enable Output"))
        self.label_2.setText(_translate("MainWindow", "Current Value"))
        self.label_3.setText(_translate("MainWindow", "Set Value"))
        self.label_4.setText(_translate("MainWindow", "mW"))
        self.label_6.setText(_translate("MainWindow", "Controls"))
        self.setTextButton.setText(_translate("MainWindow", "Set"))
        self.getPowerPushButton.setText(_translate("MainWindow", "GetPower"))