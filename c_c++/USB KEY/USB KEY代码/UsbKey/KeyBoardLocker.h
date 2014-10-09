// KeyBoardLocker.h: interface for the KeyBoardLocker class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_KEYBOARDLOCKER_H__F332AEA1_7280_49A3_9857_09A4163A79B6__INCLUDED_)
#define AFX_KEYBOARDLOCKER_H__F332AEA1_7280_49A3_9857_09A4163A79B6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
typedef BOOL(*KEYBOARDLOCKER)(BOOL,BOOL);
class KeyBoardLocker  
{
public:
	void UnloadDLL();
	BOOL Unlock();
	BOOL Lock();
	BOOL LoadDLL();
	KeyBoardLocker();
	virtual ~KeyBoardLocker();
private:
	HINSTANCE hKeyBoardLockerDLL;
	KEYBOARDLOCKER lockKeyBoard;

};

#endif // !defined(AFX_KEYBOARDLOCKER_H__F332AEA1_7280_49A3_9857_09A4163A79B6__INCLUDED_)
