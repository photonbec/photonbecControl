# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'InterfaceGUI.ui'
#
# Created: Mon Mar 11 15:56:47 2013
#      by: PyQt4 UI code generator 4.9.1
#
# WARNING! All changes made in this file will be lost!
        
from PyQt5 import QtCore, QtWidgets
try:
	from PyQt5 import QtCore, QtGui
except:
	from PySide import QtCore, QtGui
	
try:
    _fromUtf8 = QtCore.QString.fromUtf8
except AttributeError:
    _fromUtf8 = lambda s: s

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName(_fromUtf8("MainWindow"))
        MainWindow.resize(240, 200)

        self.centralwidget = QtWidgets.QWidget(MainWindow)

        self.centralwidget.setObjectName(_fromUtf8("centralwidget"))
        self.groupBox = QtWidgets.QGroupBox(self.centralwidget)
        self.groupBox.setGeometry(QtCore.QRect(0, 0, 241, 381))
        self.groupBox.setObjectName(_fromUtf8("groupBox"))
        self.powerSlider = QtWidgets.QSlider(self.groupBox)

        self.powerSlider.setGeometry(QtCore.QRect(0, 150, 141, 29))
        self.powerSlider.setMaximum(2400)
        self.powerSlider.setOrientation(QtCore.Qt.Horizontal)
        self.powerSlider.setObjectName(_fromUtf8("powerSlider"))
        
        self.enable_checkBox = QtWidgets.QCheckBox(self.groupBox)

        self.enable_checkBox.setGeometry(QtCore.QRect(50, 0, 101, 22))
        self.enable_checkBox.setObjectName(_fromUtf8("enable_checkBox"))
		
        self.power_timer_checkBox = QtWidgets.QCheckBox(self.groupBox)

        self.power_timer_checkBox.setGeometry(QtCore.QRect(155, 0, 101, 22))
        self.power_timer_checkBox.setObjectName(_fromUtf8("timer_checkBox"))
		
        self.label_2 = QtWidgets.QLabel(self.groupBox)
        self.label_2.setGeometry(QtCore.QRect(0, 50, 101, 17))
        self.label_2.setObjectName(_fromUtf8("label_2"))
        self.label_3 = QtWidgets.QLabel(self.groupBox)
        self.label_3.setGeometry(QtCore.QRect(189, 50, 51, 20))
        self.label_3.setObjectName(_fromUtf8("label_3"))
        self.label_4 = QtWidgets.QLabel(self.groupBox)
        self.label_4.setGeometry(QtCore.QRect(190, 100, 31, 20))
        self.label_4.setObjectName(_fromUtf8("label_4"))
        self.label_6 = QtWidgets.QLabel(self.groupBox)
        self.label_6.setGeometry(QtCore.QRect(0, 130, 101, 17))
        self.label_6.setObjectName(_fromUtf8("label_6"))
        self.currentLCD = QtWidgets.QLCDNumber(self.groupBox)
        self.currentLCD.setGeometry(QtCore.QRect(0, 70, 181, 51))
        self.currentLCD.setObjectName(_fromUtf8("currentLCD"))
        self.setLCD = QtWidgets.QLCDNumber(self.groupBox)
        self.setLCD.setGeometry(QtCore.QRect(190, 70, 51, 23))
        self.setLCD.setNumDigits(4)
        self.setLCD.setSegmentStyle(QtWidgets.QLCDNumber.Flat)
        self.setLCD.setObjectName(_fromUtf8("setLCD"))
        self.setText = QtWidgets.QLineEdit(self.groupBox)
        self.setText.setGeometry(QtCore.QRect(160, 150, 51, 27))
        self.setText.setObjectName(_fromUtf8("setText"))
        self.setTextButton = QtWidgets.QPushButton(self.groupBox)
        self.setTextButton.setGeometry(QtCore.QRect(210, 150, 31, 27))
        self.setTextButton.setObjectName(_fromUtf8("setTextButton"))
        self.getPowerPushButton = QtWidgets.QPushButton(self.groupBox)
        self.getPowerPushButton.setGeometry(QtCore.QRect(100, 40, 61, 27))
        self.getPowerPushButton.setObjectName(_fromUtf8("getPowerPushButton"))
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 240, 23))
        self.menubar.setObjectName(_fromUtf8("menubar"))
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName(_fromUtf8("statusbar"))
        MainWindow.setStatusBar(self.statusbar)
        
        screen = QtWidgets.QDesktopWidget().screenGeometry()
        mysize = MainWindow.geometry()
        MainWindow.move(screen.width() - mysize.width() - 15, 0)
        
        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(QtWidgets.QApplication.translate("MainWindow", "LaserController", None))
        self.groupBox.setTitle(QtWidgets.QApplication.translate("MainWindow", "Power", None))
        self.enable_checkBox.setText(QtWidgets.QApplication.translate("MainWindow", "Enable Output", None))
        self.label_2.setText(QtWidgets.QApplication.translate("MainWindow", "Current Value", None))
        self.label_3.setText(QtWidgets.QApplication.translate("MainWindow", "Set Value", None))
        self.label_4.setText(QtWidgets.QApplication.translate("MainWindow", "mW", None))
        self.label_6.setText(QtWidgets.QApplication.translate("MainWindow", "Controls", None))
        self.setTextButton.setText(QtWidgets.QApplication.translate("MainWindow", "Set", None))
        self.getPowerPushButton.setText(QtWidgets.QApplication.translate("MainWindow", "GetPower", None))
        self.power_timer_checkBox.setText(QtWidgets.QApplication.translate("MainWindow", "Poll Power", None))

if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())

