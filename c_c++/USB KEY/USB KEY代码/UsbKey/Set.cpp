// Set.cpp : implementation file
//

#include "stdafx.h"
#include "UsbKey.h"
#include "Set.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSet dialog


CSet::CSet(CWnd* pParent /*=NULL*/)
	: CDialog(CSet::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSet)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void CSet::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSet)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CSet, CDialog)
	//{{AFX_MSG_MAP(CSet)
	ON_BN_CLICKED(ID_AUTO, OnAuto)
	ON_BN_CLICKED(ID_UNAUTO, OnUnauto)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSet message handlers

void CSet::OnAuto() 
{
	// TODO: Add your control notification handler code here
	unsigned char tmp[256];
	::GetModuleFileName(NULL,(char *)tmp,256);
	//sprintf((char *)tmp,"%s","C:\\Program Files\\Microsoft Visual Studio\\MyProjects\\UsbKey\\Debug\\UsbKey.exe");
	CString tmpstring=tmp;
    
	HKEY hKEY;
	DWORD type=REG_SZ;
	DWORD size=tmpstring.GetLength()+1;
	LPCTSTR path="SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run" ;

	long ret=::RegOpenKeyEx(HKEY_LOCAL_MACHINE,path,0,KEY_WRITE, &hKEY);
	if(ret!=ERROR_SUCCESS)
	{ 
		MessageBox("错误: 修改无法打开有关的hKEY!");
		return; 
	}
	ret=::RegSetValueEx(hKEY,"UsbKey",NULL,type,tmp,size);
	if(ret!=ERROR_SUCCESS)
	{ 
		MessageBox("错误: 无法修改有关注册表信息!");
		return;
	}
	::RegCloseKey(hKEY);
	CDialog::OnOK();
	
}

void CSet::OnUnauto() 
{
	// TODO: Add your control notification handler code here
	unsigned char tmp[256];
	sprintf((char *)tmp,"%s","");
	CString tmpstring=tmp;

	HKEY hKEY;
	DWORD type=REG_SZ;
	DWORD size=tmpstring.GetLength()+1;
	LPCTSTR path="SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run" ;

	long ret=::RegOpenKeyEx(HKEY_LOCAL_MACHINE,path,0,KEY_WRITE, &hKEY);
	if(ret!=ERROR_SUCCESS)
	{ 
		MessageBox("错误: 修改无法打开有关的hKEY!");
		return; 
	}
	ret=::RegSetValueEx(hKEY,"UsbKey",NULL,type,tmp,size);
	if(ret!=ERROR_SUCCESS)
	{ 
		MessageBox("错误: 无法修改有关注册表信息!");
		return;
	}
	::RegCloseKey(hKEY);
	CDialog::OnCancel();
}
