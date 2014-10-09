; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CSet
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "UsbKey.h"

ClassCount=5
Class1=CUsbKeyApp
Class2=CUsbKeyDlg
Class3=CAboutDlg

ResourceCount=5
Resource1=IDD_USBKEY_DIALOG
Resource2=IDR_MAINFRAME
Resource3=IDD_LOGIN
Class4=CLogin
Resource4=IDD_ABOUTBOX
Class5=CSet
Resource5=IDD_SET

[CLS:CUsbKeyApp]
Type=0
HeaderFile=UsbKey.h
ImplementationFile=UsbKey.cpp
Filter=N

[CLS:CUsbKeyDlg]
Type=0
HeaderFile=UsbKeyDlg.h
ImplementationFile=UsbKeyDlg.cpp
Filter=D
BaseClass=CDialog
VirtualFilter=dWC
LastObject=CUsbKeyDlg

[CLS:CAboutDlg]
Type=0
HeaderFile=UsbKeyDlg.h
ImplementationFile=UsbKeyDlg.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_USBKEY_DIALOG]
Type=1
Class=CUsbKeyDlg
ControlCount=7
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342309121
Control4=IDC_STATIC,static,1342177806
Control5=IDC_Tishi,button,1342177287
Control6=IDC_Text,static,1342308864
Control7=IDC_SET,button,1342242816

[DLG:IDD_LOGIN]
Type=1
Class=CLogin
ControlCount=5
Control1=IDOK,button,1342242817
Control2=IDC_USER,static,1342308352
Control3=IDC_MIMA,static,1342308352
Control4=IDC_EDIT1,edit,1350631552
Control5=IDC_EDIT2,edit,1350631584

[CLS:CLogin]
Type=0
HeaderFile=Login.h
ImplementationFile=Login.cpp
BaseClass=CDialog
Filter=D
LastObject=CLogin
VirtualFilter=dWC

[DLG:IDD_SET]
Type=1
Class=CSet
ControlCount=2
Control1=ID_AUTO,button,1342242817
Control2=ID_UNAUTO,button,1342242816

[CLS:CSet]
Type=0
HeaderFile=Set.h
ImplementationFile=Set.cpp
BaseClass=CDialog
Filter=D
LastObject=ID_UNAUTO
VirtualFilter=dWC

