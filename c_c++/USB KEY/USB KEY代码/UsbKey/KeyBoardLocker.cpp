// KeyBoardLocker.cpp: implementation of the KeyBoardLocker class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "UsbKey.h"
#include "KeyBoardLocker.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

KeyBoardLocker::KeyBoardLocker()
{

}

KeyBoardLocker::~KeyBoardLocker()
{

}
BOOL KeyBoardLocker::LoadDLL()
{
	hKeyBoardLockerDLL=::LoadLibrary("KeyBoardDLL.dll");//加载DLL
	//hKeyBoardLockerDLL=::LoadLibrary("../KeyBoardDLL/Debug/KeyBoardDLL.dll");//加载DLL
	if(hKeyBoardLockerDLL!=NULL)
	{
		lockKeyBoard=(KEYBOARDLOCKER)GetProcAddress(hKeyBoardLockerDLL,"DisableTaskKeys");
		if(lockKeyBoard==NULL)
		{
			MessageBox(0,"函数调用失败！！！","加载函数错误！！！",MB_OK);
			return FALSE;
		}
		//MessageBox(0,"锁定键盘3","锁定",MB_OK);
		return TRUE;
	}
	MessageBox(0,"动态链接库加载失败！！！","加载运行库错误！！！",MB_OK);
	return FALSE;

}

BOOL KeyBoardLocker::Lock()//锁定键盘
{   //MessageBox(0,"锁定键盘1","锁定",MB_OK);
	if(lockKeyBoard!=NULL)
	{   //MessageBox(0,"锁定键盘2","锁定",MB_OK);
		lockKeyBoard(TRUE,FALSE);
		return TRUE;
	}
	return FALSE;
 
}

BOOL KeyBoardLocker::Unlock()//解锁
{
	if(lockKeyBoard!=NULL)
	{
		lockKeyBoard(FALSE,FALSE);
		return TRUE;
	}
	return FALSE;

}

void KeyBoardLocker::UnloadDLL()
{
	::FreeLibrary(hKeyBoardLockerDLL);

}
