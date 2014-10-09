#include <windows.h>
#include <windowsx.h>
#include "main.h"
#include "resource.h"
#include <string.h>

int Initialization=1;	//定时器用参数
char wificonf[]="D:\\wificonf";

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

BOOL WINAPI Main_Proc1(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
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


void wificonfun(HWND hwnd,wchar_t confname[],wchar_t confpass[]);

/*******************************************************************************
*  Main_OnInitDialog
*/
BOOL Main_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
    /* Set app icons */
	HWND hwndList = GetDlgItem(hwnd,IDC_COMTIME);
	wchar_t wtimestr[128];
	wchar_t confname[60],confpass[60];
	HWND hwndEdOut = GetDlgItem(hwnd,IDC_PIC);
    HICON hIcon = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(1));
    SendMessage(hwnd, WM_SETICON, TRUE,  (LPARAM)hIcon);
    SendMessage(hwnd, WM_SETICON, FALSE, (LPARAM)hIcon);
    
	SetTimer(hwnd,1,1000,myTimeProc);
	Static_SetIcon(hwndEdOut,hIcon);
	returntime(wtimestr);
	SetDlgItemText(hwnd,IDC_STATICTIME,wtimestr);
	{
		wificonfun(hwnd,confname,confpass);
		SetDlgItemText(hwnd,IDC_USERNAME,confname);
		SetDlgItemText(hwnd,IDC_USERPASS,confpass);
	}
	ComboBox_AddItemData(hwndList,L"立即");
	ComboBox_AddItemData(hwndList,L"一分钟");
	ComboBox_AddItemData(hwndList,L"五分钟");
	ComboBox_AddItemData(hwndList,L"十分钟");
	ComboBox_AddItemData(hwndList,L"半小时");
	ComboBox_AddItemData(hwndList,L"一小时");
	ComboBox_AddItemData(hwndList,L"两小时");
	ComboBox_SetCurSel(hwndList,4 );
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
	int shutdowntime;
	HWND hwndEdOut = GetDlgItem(hwnd,IDC_PIC);
	HWND hwndList = GetDlgItem(hwnd,IDC_COMTIME);
	HINSTANCE hInstance1;
	HICON hIconRotate = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(1));
	FILE *fp;
	int passlen;
	char cmdstr[128];
	wchar_t username[60],userpass[60],summary[254];
	char cusername[127],cuserpass[127],code[254];
	GetDlgItemText(hwnd,IDC_USERNAME,username,30);
	GetDlgItemText(hwnd,IDC_USERPASS,userpass,30);
		memset(cusername,0,127);
		memset(cuserpass,0,127);
	w2c(username,cusername);
	w2c(userpass,cuserpass);
	wsprintf(summary,L"用户名：%s\n密码：%s",username,userpass);
	sprintf(code,"netsh wlan set hostednetwork mode=allow ssid=%s key=%s",cusername,cuserpass);
	passlen=strlen(cuserpass);
    switch(id)
    {
        case IDC_OK:
			if(passlen<8||passlen>=20)
			{
				 MessageBox(hwnd,TEXT("密码必须是8~20位的字符串"),TEXT("CJ_Studio"),MB_OK|MB_ICONEXCLAMATION  );
				 SetDlgItemText(hwnd,IDC_USERPASS,NULL);
			}
			else if(IDYES == MessageBox(hwnd,summary,TEXT("CJ_Studio"),MB_YESNO))
			{
				fp=fopen(wificonf,"w+");
				fclose(fp);
				fp=fopen(wificonf,"w+");
				fprintf(fp,"%s \n",cusername);
				fprintf(fp,"%s \n",cuserpass);
				fclose(fp);
				WinExec(code,SW_HIDE);
			};
			break;

		case IDC_RUN:
			if(IDYES == MessageBox(hwnd,summary,TEXT("CJ_Studio"),MB_YESNO))
			{
				WinExec("netsh wlan start hostednetwork",SW_HIDE);
				SetTimer(hwnd,2,100,myTimeProc2);
			};
			break;

		case IDC_STOPWIFI:
			WinExec("netsh wlan stop hostednetwork",SW_HIDE);
			KillTimer(hwnd,2);
			WinExec("shutdown -a",SW_HIDE);
			Static_SetIcon(hwndEdOut,hIconRotate);
			MessageBox(hwnd,L"WIFI功能已关闭，定时关机选项已取消！！！",L"CJ_Studio",MB_OK);
			break;

		case IDC_BUTPOWER:
			SendMessage(hwnd,   WM_SYSCOMMAND,   SC_MONITORPOWER,  2); //关闭显示器
			break;

		case IDC_BUTSHUTDOWN:
			shutdowntime=ReListNo(hwndList);
			SetTimer(hwnd,4,shutdowntime*1000,myTimeProc4);
			sprintf(cmdstr,"shutdown -s -t %d",shutdowntime);
			WinExec(cmdstr,SW_HIDE);
			break;
		
		case IDC_BUTSHUTPOWER:
			shutdowntime=ReListNo(hwndList);
			sprintf(cmdstr,"shutdown -s -t %d",shutdowntime);
			WinExec(cmdstr,SW_HIDE);
			WinExec("rundll32.exe user32.dll,LockWorkStation ",SW_HIDE);
			SendMessage(hwnd,  WM_SYSCOMMAND,   SC_MONITORPOWER,  2);
			break;

        case IDC_CANCEL:
			DialogBox(hInstance1, MAKEINTRESOURCE(IDD_ABOUT), NULL, Main_Proc1);
            MessageBox(hwnd,TEXT("  用一生下载你 !!!"),TEXT("CJ_Studio"),MB_OK);
			SetTimer(hwnd,3,1000,myTimeProc3);
        break;

		case IDC_BUTTON1 :
			 ShellExecute(0, NULL, L"http://cjstudio.tk", NULL,NULL, SW_NORMAL);
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

VOID CALLBACK myTimeProc2(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime)
{
	HWND hwndEdOut = GetDlgItem(hwnd,IDC_PIC);
	HICON hIconRotate1 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON3));
	HICON hIconRotate2 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON4));
	HICON hIconRotate3 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON5));
	HICON hIconRotate4 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON6));
	HICON hIconRotate5 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON7));
	HICON hIconRotate6 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON8));
	HICON hIconRotate7 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON9));
	HICON hIconRotate8 = LoadIcon((HINSTANCE) GetWindowLong(hwnd, GWL_HINSTANCE) ,MAKEINTRESOURCE(IDI_ICON2));
	Initialization++;
	switch(Initialization%8)
	{
	case 0:Static_SetIcon(hwndEdOut,hIconRotate1);break;
	case 1:Static_SetIcon(hwndEdOut,hIconRotate2);break;
	case 2:Static_SetIcon(hwndEdOut,hIconRotate3);break;
	case 3:Static_SetIcon(hwndEdOut,hIconRotate4);break;
	case 4:Static_SetIcon(hwndEdOut,hIconRotate5);break;
	case 5:Static_SetIcon(hwndEdOut,hIconRotate6);break;
	case 6:Static_SetIcon(hwndEdOut,hIconRotate7);break;
	case 7:Static_SetIcon(hwndEdOut,hIconRotate8);break;
	default:return;
	}
}

VOID CALLBACK myTimeProc3(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime)
{
	EndDialog(hwnd, 0);
}

VOID CALLBACK myTimeProc4(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime)
{
	ExitWindowsEx(EWX_SHUTDOWN, 0);
	KillTimer(hwnd,4);
	//MessageBox(hwnd,"","",MB_OK);
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

void wificonfun(HWND hwnd,wchar_t wconfname[],wchar_t wconfpass[])
{
	FILE *fp;
	char confname[127]="MyWIFI_Network",confpass[127]="abcd1234";
	fp=fopen(wificonf,"r");
	if(NULL == fp)
	{
		c2w(confname,wconfname);
		c2w(confpass,wconfpass);
		return;
	}
	else
	{
		memset(confname,0,127);
		memset(confpass,0,127);
		fscanf(fp,"%s\n%s",confname,confpass);
	}
	c2w(confname,wconfname);
	c2w(confpass,wconfpass);
	fclose(fp);

}

int ReListNo(HWND hwndList)
{
	int Num;
	Num=ComboBox_GetCurSel(hwndList);
	switch(Num)
	{
	case 0:return 0;
	case 1:return 1*60;
	case 2:return 5*60;
	case 3:return 10*60;
	case 4:return 30*60;
	case 5:return 60*60;
	case 6:return 2*60*60;
	default : return 5;
	}
}