// Login.cpp : implementation file
//

#include "stdafx.h"
#include "UsbKey.h"
#include "Login.h"
#include "Set.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CLogin dialog


CLogin::CLogin(CWnd* pParent /*=NULL*/)
	: CDialog(CLogin::IDD, pParent)
{
	//{{AFX_DATA_INIT(CLogin)
	//}}AFX_DATA_INIT
}


void CLogin::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CLogin)
	DDX_Control(pDX, IDC_EDIT1, m_eidtname);
	DDX_Control(pDX, IDC_EDIT2, m_editpassword);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CLogin, CDialog)
	//{{AFX_MSG_MAP(CLogin)
	ON_EN_CHANGE(IDC_EDIT1, OnChangeName)
	ON_EN_CHANGE(IDC_EDIT2, OnChangeNumber)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CLogin message handlers

void CLogin::OnChangeName() 
{
	// TODO: If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialog::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.
	
	// TODO: Add your control notification handler code here
	
}

void CLogin::OnChangeNumber() 
{
	// TODO: If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialog::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.
	
	// TODO: Add your control notification handler code here
	
}

void CLogin::OnOK() 
{
	// TODO: Add extra validation here
	CString Temp;
	CString Tempx;
	m_eidtname.GetWindowText(Temp);
	m_editpassword.GetWindowText(Tempx);
	
	if (Temp == _T("ZCK") && Tempx == _T("123456"))
	{   
		CSet set;
		set.DoModal();
		CDialog::OnOK();
	}
	else
		MessageBox(_T("”√ªßªÚ√‹¬Î¥ÌŒÛ!"), _T("µ«¬Ω ß∞‹"), MB_ICONERROR);
}
