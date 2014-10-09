// MouseLocker.h: interface for the MouseLocker class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_MOUSELOCKER_H__8FA54E86_5D97_4D02_BB80_F6E506A061A4__INCLUDED_)
#define AFX_MOUSELOCKER_H__8FA54E86_5D97_4D02_BB80_F6E506A061A4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
typedef BOOL(*LOADMOUSEHOOK)();
typedef BOOL(*UNLOADMOUSEHOOK)();
class MouseLocker  
{
public:
	void UnloadDLL();
	BOOL LoadDLL();
	BOOL Unlock();
	BOOL Lock();
	MouseLocker();
	virtual ~MouseLocker();
private:
	HINSTANCE hMouseLockerDLL;
	UNLOADMOUSEHOOK unloadhook;
	LOADMOUSEHOOK loadhook;

};

#endif // !defined(AFX_MOUSELOCKER_H__8FA54E86_5D97_4D02_BB80_F6E506A061A4__INCLUDED_)
