// UsbKey.h : main header file for the USBKEY application
//

#if !defined(AFX_USBKEY_H__D558C2FF_7521_443D_9A57_C1161C682A4D__INCLUDED_)
#define AFX_USBKEY_H__D558C2FF_7521_443D_9A57_C1161C682A4D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CUsbKeyApp:
// See UsbKey.cpp for the implementation of this class
//

class CUsbKeyApp : public CWinApp
{
public:
	CUsbKeyApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUsbKeyApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CUsbKeyApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_USBKEY_H__D558C2FF_7521_443D_9A57_C1161C682A4D__INCLUDED_)
