// MouseDLL.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "MouseDLL.h"
HHOOK hhkHook=NULL;//定义钩子句柄
HINSTANCE hInstance=NULL;

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    switch (ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
		case DLL_PROCESS_DETACH:
			break;
    }
    hInstance=(HINSTANCE)hModule;
    return TRUE;
}


// This is an example of an exported variable
MOUSEDLL_API int nMouseDLL=0;

// This is an example of an exported function.
MOUSEDLL_API int fnMouseDLL(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see MouseDLL.h for the class definition
//CMouseDLL::CMouseDLL()
//{ 
//	return; 
//}
LRESULT CALLBACK HookProc(int nCode,WPARAM wParam,LPARAM lParam)//消息处理函数 回调函数
{

	if(nCode<0)
	{
		return CallNextHookEx(hhkHook,nCode,wParam,lParam);//循环设置钩子保证钩子在消息链的顶端
	}
	if(nCode!=HC_ACTION)
	{
		return CallNextHookEx(hhkHook,nCode,wParam,lParam);
	}
	return 1;//使鼠标不起作用！！！！
}
//导出函数：启动鼠标锁定 
MOUSEDLL_API BOOL EnableMouseLock()
{
	if(!(hhkHook=SetWindowsHookEx(WH_MOUSE,(HOOKPROC)HookProc,hInstance,0)))//安装钩子
		return FALSE;
	return TRUE;
}
//导出函数：解除鼠标锁定
MOUSEDLL_API BOOL DisableMouseLock()
{
	return UnhookWindowsHookEx(hhkHook);//卸载钩子
}
