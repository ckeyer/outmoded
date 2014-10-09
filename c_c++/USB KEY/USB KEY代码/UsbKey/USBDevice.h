// USBDevice.h: interface for the USBDevice class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_USBDEVICE_H__791AEEF9_8CB1_49DD_9CBB_9686866BA8BA__INCLUDED_)
#define AFX_USBDEVICE_H__791AEEF9_8CB1_49DD_9CBB_9686866BA8BA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

extern "C" //C编译器和CPP编译器编译链接时会出现差异的问题
{
#include "setupapi.h"
#include "hidsdi.h"
#include "usbioctl.h"
}
#include "winioctl.h"
#include "devioctl.h"
#define INTERFACE_DETAIL_SIZE    1024
#define NUM_HCS_TO_CHECK 10
class USBDevice  
{
public:
	BOOL  UsbKeyCheck(PUSB_NODE_CONNECTION_INFORMATION connectionInfo);
	PCHAR WideStrToMultiStr(PWCHAR WideStr);
	PCHAR GetRootHubName(HANDLE HostController);
	BOOL  SearchDevice();
	USBDevice();
	virtual ~USBDevice();

};

#endif // !defined(AFX_USBDEVICE_H__791AEEF9_8CB1_49DD_9CBB_9686866BA8BA__INCLUDED_)
