// MouseLocker.cpp: implementation of the MouseLocker class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "UsbKey.h"
#include "MouseLocker.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

MouseLocker::MouseLocker()
{

}

MouseLocker::~MouseLocker()
{

}
BOOL MouseLocker::Lock()//锁定鼠标
{   //MessageBox(0,"锁定鼠标！！！","锁定！！！",MB_OK);
	if(loadhook!=NULL)
	{   //MessageBox(0,"锁定鼠标1！！！","锁定！！！",MB_OK);
		loadhook();//调用MouseDLL.dll的输出函数
		return TRUE;
	}
	return TRUE;

}

BOOL MouseLocker::Unlock()//解锁
{
	if(unloadhook!=NULL)
	{
        unloadhook();//调用MouseDLL.dll的输出函数
	    return TRUE;
	}
	return FALSE;
}

BOOL MouseLocker::LoadDLL()
{
    hMouseLockerDLL=::LoadLibrary("MouseDLL.dll"); //加载DLL
	//hMouseLockerDLL = ::LoadLibrary("../MouseDLL/Debug/MouseDLL.dll");
	if(hMouseLockerDLL!=NULL)
	{
		loadhook=(LOADMOUSEHOOK)GetProcAddress(hMouseLockerDLL,"EnableMouseLock");
		//loadhook指向MouseDLL.dll的锁定输出函数

		unloadhook=(UNLOADMOUSEHOOK)GetProcAddress(hMouseLockerDLL,"DisableMouseLock");
		//unloadhook指向MouseDLL.dll的解锁函数

		if(loadhook==NULL||unloadhook==NULL)
		{
			MessageBox(0,"函数调用失败！！！","加载函数错误！！！",MB_OK);
			return FALSE;
		}
		return TRUE;
	}
	MessageBox(0,"动态链接库加载失败！！！","加载运行库错误！！！",MB_OK);
	return FALSE;
}


void MouseLocker::UnloadDLL() //释放链接库资源
{
    ::FreeLibrary(hMouseLockerDLL);
}