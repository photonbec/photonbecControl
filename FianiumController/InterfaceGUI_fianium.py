# This is a horrific hack, but might work
#try:
    #from PyQt5 import QtCore, QtGui
#except:
    #from PySide import QtCore, QtGui
from PyQt5 import QtGui, QtCore, uic, QtWidgets
from PyQt5.QtWidgets import QMainWindow, QApplication
from PyQt5.QtCore import *

try:
    _fromUtf8 = QtCore.QString.fromUtf8
except AttributeError:
    _fromUtf8 = lambda s: s


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(250, 420)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.groupBox = QtWidgets.QGroupBox(self.centralwidget)
        self.groupBox.setGeometry(QtCore.QRect(0, 20, 260, 421))
        self.groupBox.setObjectName("groupBox")

        self.enable_checkBox = QtWidgets.QCheckBox(self.groupBox)
        self.enable_checkBox.setGeometry(QtCore.QRect(50, 10, 101, 22))
        self.enable_checkBox.setObjectName("enable_checkBox")

        self.power_timer_checkBox = QtWidgets.QCheckBox(self.groupBox)
        self.power_timer_checkBox.setGeometry(QtCore.QRect(155, 10, 101, 22))
        self.power_timer_checkBox.setObjectName("timer_checkBox")

        self.label_2 = QtWidgets.QLabel(self.groupBox)
        self.label_2.setGeometry(QtCore.QRect(0, 50, 101, 17))
        self.label_2.setObjectName("label_2")
        self.label_3 = QtWidgets.QLabel(self.groupBox)
        self.label_3.setGeometry(QtCore.QRect(189, 50, 51, 20))
        self.label_3.setObjectName("label_3")
        self.label_4 = QtWidgets.QLabel(self.groupBox)
        self.label_4.setGeometry(QtCore.QRect(190, 100, 31, 20))
        self.label_4.setObjectName("label_4")

        self.label_5 = QtWidgets.QLabel(self.groupBox)
        self.label_5.setGeometry(QtCore.QRect(190, 180, 31, 20))
        self.label_5.setObjectName("label_5")

        self.label_6 = QtWidgets.QLabel(self.groupBox)
        self.label_6.setGeometry(QtCore.QRect(0, 70, 101, 17))
        self.label_6.setObjectName(_fromUtf8("label_6"))

        self.label_7 = QtWidgets.QLabel(self.groupBox)
        self.label_7.setGeometry(QtCore.QRect(0, 150, 101, 17))
        self.label_7.setObjectName(_fromUtf8("label_6"))

        self.label_8 = QtWidgets.QLabel(self.groupBox)
        self.label_8.setGeometry(QtCore.QRect(75, 280, 31, 27))
        self.label_8.setObjectName(_fromUtf8("label_7"))

        self.label_9 = QtWidgets.QLabel(self.groupBox)
        self.label_9.setGeometry(QtCore.QRect(205, 280, 31, 27))
        self.label_9.setObjectName(_fromUtf8("label_7"))

        self.currentLCD_pulse_energy = QtWidgets.QLCDNumber(self.groupBox)
        self.currentLCD_pulse_energy.setGeometry(QtCore.QRect(0, 90, 181, 51))
        self.currentLCD_pulse_energy.setObjectName(_fromUtf8("currentLCD_Energy"))

        self.currentLCD_rr = QtWidgets.QLCDNumber(self.groupBox)
        self.currentLCD_rr.setGeometry(QtCore.QRect(0, 170, 181, 51))
        self.currentLCD_rr.setObjectName(_fromUtf8("currentLCD_RepRate"))

        self.setLCD_pulse_energy = QtWidgets.QLCDNumber(self.groupBox)
        self.setLCD_pulse_energy.setGeometry(QtCore.QRect(20, 280, 51, 27))
        self.setLCD_pulse_energy.setObjectName(_fromUtf8("currentLCD_Energy"))

        self.currentLCD_alarms = QtWidgets.QTextEdit(self.groupBox)
        self.currentLCD_alarms.setGeometry(QtCore.QRect(20, 320, 200, 51))
        self.currentLCD_alarms.setObjectName(_fromUtf8("LaserSafetyAlarms"))

        self.setLCD_rr = QtWidgets.QLCDNumber(self.groupBox)
        self.setLCD_rr.setGeometry(QtCore.QRect(150, 280, 51, 27))
        self.setLCD_rr.setObjectName(_fromUtf8("currentLCD_RepRate"))

        self.setText_pulse_energy = QtWidgets.QLineEdit(self.groupBox)
        self.setText_pulse_energy.setGeometry(QtCore.QRect(20, 250, 51, 27))
        self.setText_pulse_energy.setObjectName(_fromUtf8("setText_Energy"))
        self.setTextButton_pulse_energy = QtWidgets.QPushButton(self.groupBox)
        self.setTextButton_pulse_energy.setGeometry(QtCore.QRect(75, 250, 31, 27))
        self.setTextButton_pulse_energy.setObjectName(_fromUtf8("setTextButton1"))

        self.setText_rr = QtWidgets.QLineEdit(self.groupBox)
        self.setText_rr.setGeometry(QtCore.QRect(150, 250, 51, 27))
        self.setText_rr.setObjectName(_fromUtf8("setText_RepRate"))
        self.setTextButton_rr = QtWidgets.QPushButton(self.groupBox)
        self.setTextButton_rr.setGeometry(QtCore.QRect(205, 250, 31, 27))
        self.setTextButton_rr.setObjectName(_fromUtf8("setTextButton2"))

        self.getDataPushButton = QtWidgets.QPushButton(self.groupBox)
        self.getDataPushButton.setGeometry(QtCore.QRect(150, 40, 61, 27))
        self.getDataPushButton.setObjectName(_fromUtf8("getEnergyPushButton"))

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
        MainWindow.move(screen.width() - mysize.width() - 275, 0)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    # p=self.palette()
    # p.setColor(self.backgroundRole(),Qt.red)
    # self.setPalette(p)
    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(
            QtCore.QCoreApplication.translate("MainWindow", "FianiumController"))
        self.groupBox.setTitle(
            QtCore.QCoreApplication.translate("MainWindow", "Power"))
        self.enable_checkBox.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Enable Output"))
        self.label_4.setText(QtCore.QCoreApplication.translate("MainWindow", "nJ"))
        self.label_5.setText(QtCore.QCoreApplication.translate("MainWindow", "MHz"))
        self.label_6.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Pulse Energy"))
        self.label_7.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Repetition Rate"))
        self.label_8.setText(QtCore.QCoreApplication.translate("MainWindow", "nJ"))
        self.label_9.setText(QtCore.QCoreApplication.translate("MainWindow", "MHz"))
        self.setTextButton_pulse_energy.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Set"))
        self.setTextButton_rr.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Set"))
        self.getDataPushButton.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Get Data"))
        self.power_timer_checkBox.setText(
            QtCore.QCoreApplication.translate("MainWindow", "Poll Power"))

'''
if __name__ == "__main__":
    import sys

    app = QtGui.QApplication(sys.argv)
    MainWindow = QtGui.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    app_icon = QtGui.QIcon()
    app_icon.addFile('fianium_icon.png', QtCore.QSize(16, 16))
    app.setWindowIcon(app_icon)
    MainWindow.show()
    sys.exit(app.exec_())
'''