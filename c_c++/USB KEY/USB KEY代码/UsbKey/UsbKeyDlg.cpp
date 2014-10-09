// UsbKeyDlg.cpp : implementation file
//

#include "stdafx.h"
#include "UsbKey.h"
#include "UsbKeyDlg.h"
#include "Login.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUsbKeyDlg dialog

CUsbKeyDlg::CUsbKeyDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CUsbKeyDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CUsbKeyDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CUsbKeyDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CUsbKeyDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CUsbKeyDlg, CDialog)
	//{{AFX_MSG_MAP(CUsbKeyDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_SET, OnSet)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUsbKeyDlg message handlers

BOOL CUsbKeyDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
    
	if(!Mylocker.LoadDLL())
		return FALSE;
	ShowWindow(SW_SHOWMAXIMIZED);
	if(!KeyDevice.SearchDevice())
	{
		//AfxMessageBox("开始锁~~",0,0);
	    LockSystem();
	}
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CUsbKeyDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CUsbKeyDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CUsbKeyDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CUsbKeyDlg::LockSystem()

{   
	//AfxMessageBox("没有搜索到正确的USB KEY，进入系统锁定状态!!!",0,0);
    ShowWindow(SW_SHOWMAXIMIZED);
//	AfxMessageBox("下一步",0,0);
	if(!Mylocker.Isdisable())//!Mylocker.Isdisable()
	{   //AfxMessageBox("bad",0,0);
		//WinExec("Usb.scr",SW_MAXIMIZE);//运行屏保
		Mylocker.Lock();
		
	}
}

void CUsbKeyDlg::UnLockSystem()
{   //AfxMessageBox("搜索到正确的USB KEY，解除系统锁定状态!!!",0,0);
	ShowWindow(SW_HIDE);
	if(Mylocker.Isdisable())
	{   //AfxMessageBox("good",0,0);
		Mylocker.Unlock();
        
	}

}

BOOL CUsbKeyDlg::DestroyWindow() 
{
	// TODO: Add your specialized code here and/or call the base class
	 Mylocker.UnloadDLL();
	return CDialog::DestroyWindow();
}

LRESULT CUsbKeyDlg::WindowProc(UINT message, WPARAM wParam, LPARAM lParam) 
{
	// TODO: Add your specialized code here and/or call the base class

	if(WM_DEVICECHANGE==message)
	{
		if(KeyDevice.SearchDevice())//找到符合设备就解锁
			UnLockSystem();
		else LockSystem();   //否则锁定
	}
	
	return CDialog::WindowProc(message, wParam, lParam);
}

void CUsbKeyDlg::OnSet() 
{
	// TODO: Add your control notification handler code here
	CLogin loginDlg;
    loginDlg.DoModal();
	
}
