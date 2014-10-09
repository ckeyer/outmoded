// UsbKeyDlg.h : header file
//

#if !defined(AFX_USBKEYDLG_H__A7498B2F_0820_4F3C_8E73_46F04CAA4082__INCLUDED_)
#define AFX_USBKEYDLG_H__A7498B2F_0820_4F3C_8E73_46F04CAA4082__INCLUDED_

#include "SystemLocker.h"	// Added by ClassView
#include "USBDevice.h"	// Added by ClassView
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CUsbKeyDlg dialog

class CUsbKeyDlg : public CDialog
{
// Construction
public:
	void UnLockSystem();
	void LockSystem();
	CUsbKeyDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CUsbKeyDlg)
	enum { IDD = IDD_USBKEY_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CUsbKeyDlg)
	public:
	virtual BOOL DestroyWindow();
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual LRESULT WindowProc(UINT message, WPARAM wParam, LPARAM lParam);
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CUsbKeyDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSet();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	SystemLocker Mylocker;
	USBDevice KeyDevice;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_USBKEYDLG_H__A7498B2F_0820_4F3C_8E73_46F04CAA4082__INCLUDED_)
