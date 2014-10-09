#include <windows.h>
#include <windowsx.h>
#include "main.h"
#include "resource.h"
BOOL WINAPI Main_Proc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    switch(uMsg)
    {
        /* BEGIN MESSAGE CRACK */
        HANDLE_MSG(hWnd, WM_INITDIALOG, Main_OnInitDialog);
        HANDLE_MSG(hWnd, WM_COMMAND, Main_OnCommand);
        HANDLE_MSG(hWnd,WM_CLOSE, Main_OnClose);
        /* END MESSAGE CRACK */
    }

    return FALSE;
}

/*******************************************************************************
*  Main_OnInitDialog
*/
BOOL Main_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
    /* Set app icons */
	wchar_t wtimestr[128];
    HICON hIcon = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(1));
    SendMessage(hwnd, WM_SETICON, TRUE,  (LPARAM)hIcon);
    SendMessage(hwnd, WM_SETICON, FALSE, (LPARAM)hIcon);
    
	SetTimer(hwnd,1,1000,myTimeProc);
	returntime(wtimestr);
	SetDlgItemText(hwnd,IDC_STATICTIME,wtimestr);

    /*
    * Add initializing code here
    */
    
    return TRUE;
}

/*******************************************************************************
*  Main_OnCommand
*/
void Main_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
    switch(id)
    {
        case IDC_OK:
            MessageBox(hwnd,TEXT("You clicked OK!"),TEXT("newcfree"),MB_OK);
            EndDialog(hwnd, id);
        break;
        case IDC_CANCEL:
            MessageBox(hwnd,TEXT("You clicked Cancel!"),TEXT("newcfree"),MB_OK);
            EndDialog(hwnd, id);
        break;
        default:break;
    }

}

/*******************************************************************************
*  Main_OnClose
*/
void Main_OnClose(HWND hwnd)
{
    EndDialog(hwnd, 0);
}


VOID CALLBACK myTimeProc(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime)
{
	wchar_t wtimestr[128];
		returntime(wtimestr);
		SetDlgItemText(hwnd,IDC_STATICTIME,wtimestr);
}

void c2w(char *str,wchar_t *t)
{
	int length = strlen(str)+1;
	//wchar_t *t = (wchar_t*)malloc(sizeof(wchar_t)*length);
	memset(t,0,length*sizeof(wchar_t));
	MultiByteToWideChar(CP_ACP,0,str,strlen(str),t,length);
}

void w2c(const wchar_t *pwstr,char *pcstr)
{
	size_t len=wcslen(pwstr)*2+1;
	int nlength=wcslen(pwstr);//获取转换后的长度
	int nbytes = WideCharToMultiByte( 0,0,pwstr,nlength,NULL,0,NULL,NULL );
	if(nbytes>len)  
	{
		nbytes=len;
	}
	WideCharToMultiByte( 0,0,pwstr,nlength,pcstr,nbytes,NULL,NULL );
}

void returntime(wchar_t *wtimestr)
{
	time_t a;
	char ctimestr[257];
	char str[20];
	struct tm *stm1;
	time_t tm1;
	tm1=time(NULL);
	stm1=localtime(&tm1);
	sprintf(ctimestr,"%4d/%d/%d  %2d.%2d.%02d\n",stm1->tm_year+1900,stm1->tm_mon+1,stm1->tm_mday,stm1->tm_hour,stm1->tm_min,stm1->tm_sec);
	c2w(ctimestr,wtimestr);
}