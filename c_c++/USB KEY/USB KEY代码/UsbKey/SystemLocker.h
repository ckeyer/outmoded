// SystemLocker.h: interface for the SystemLocker class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SYSTEMLOCKER_H__CE39C2F9_0267_491D_91A2_AA9E2047F7A1__INCLUDED_)
#define AFX_SYSTEMLOCKER_H__CE39C2F9_0267_491D_91A2_AA9E2047F7A1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#include "MouseLocker.h" //添加头文件
#include "KeyBoardLocker.h"
class SystemLocker  
{
public:
	BOOL UnloadDLL();
	BOOL Isdisable();
	BOOL LoadDLL();
	BOOL Unlock();
	BOOL Lock();
	SystemLocker();
	virtual ~SystemLocker();
private:
	BOOL bDisable;
	KeyBoardLocker keyboardlocker;
    MouseLocker mouselocker;


};

#endif // !defined(AFX_SYSTEMLOCKER_H__CE39C2F9_0267_491D_91A2_AA9E2047F7A1__INCLUDED_)
