// KeyBoardDLL.cpp : 定义 DLL 应用程序的入口点。
//

// 如果必须将位于下面指定平台之前的平台作为目标，请修改下列定义。
// 有关不同平台对应值的最新信息，请参考 MSDN。
#ifndef WINVER				// 允许使用特定于 Windows XP 或更高版本的功能。
#define WINVER 0x0501		// 将此值更改为相应的值，以适用于 Windows 的其他版本。
#endif

#ifndef _WIN32_WINNT		// 允许使用特定于 Windows XP 或更高版本的功能。
#define _WIN32_WINNT 0x0501	// 将此值更改为相应的值，以适用于 Windows 的其他版本。
#endif						

#ifndef _WIN32_WINDOWS		// 允许使用特定于 Windows 98 或更高版本的功能。
#define _WIN32_WINDOWS 0x0410 // 将此值更改为适当的值，以指定将 Windows Me 或更高版本作为目标。
#endif

#ifndef _WIN32_IE			// 允许使用特定于 IE 6.0 或更高版本的功能。
#define _WIN32_IE 0x0600	// 将此值更改为相应的值，以适用于 IE 的其他版本。
#endif

#define WIN32_LEAN_AND_MEAN		// 从 Windows 头中排除极少使用的资

#include "windows.h"
#include "KeyBoardDLL.h"

#pragma data_seg(".mydata")
HHOOK g_hHookKbdLL=NULL;
BOOL g_bBeep=FALSE;
#pragma data_seg()
#pragma comment(linker,"/SECTION:.mydata,RWS")

HMODULE g_hInstance = NULL;

BOOL APIENTRY DllMain( HMODULE hModule,
					  DWORD  ul_reason_for_call,
					  LPVOID lpReserved
					  )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		g_hInstance = hModule;
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

KEYBOARDDLL_API LRESULT CALLBACK MyTaskKeyHookLL(int nCode,WPARAM wp,LPARAM lp)//wp键值
{
	KBDLLHOOKSTRUCT *pkh=(KBDLLHOOKSTRUCT*)lp;

	if(nCode==HC_ACTION)//消息发送给窗口
	{
		if(g_bBeep&&(wp==WM_SYSKEYDOWN||wp==WM_KEYDOWN))
			MessageBeep(0);
		return 1;
	}
	return CallNextHookEx(g_hHookKbdLL,nCode,wp,lp);
}

KEYBOARDDLL_API BOOL DisableTaskKeys(BOOL bDisable, BOOL bBeep)
{ 
	if(bDisable)
	{
		if(!g_hHookKbdLL)
		{
			g_hHookKbdLL = SetWindowsHookEx(WH_KEYBOARD_LL, MyTaskKeyHookLL, g_hInstance, 0);
		}
	}//WH_KEYBOARD_LL
	else if(g_hHookKbdLL!=NULL)
	{
		UnhookWindowsHookEx(g_hHookKbdLL);
		g_hHookKbdLL=NULL;
	}
	g_bBeep=bBeep;
	return AreTaskKeysDisabled();
}

KEYBOARDDLL_API BOOL AreTaskKeysDisabled()
{
	return g_hHookKbdLL!=NULL;
}