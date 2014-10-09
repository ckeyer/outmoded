#ifndef _MAIN_H
#define _MAIN_H

#include <windows.h>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>

BOOL WINAPI Main_Proc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
BOOL Main_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
void Main_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
void Main_OnClose(HWND hwnd);
	void returntime(wchar_t *wtimestr);
	void w2c(const wchar_t *pwstr,char *pcstr);
	void c2w(char *str,wchar_t *t);
	VOID CALLBACK myTimeProc(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime);
	VOID CALLBACK myTimeProc2(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime);
	VOID CALLBACK myTimeProc3(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime);
	VOID CALLBACK myTimeProc4(HWND hwnd,UINT message,UINT iTimerID,DWORD dwtime);
	int ReListNo(HWND hwnd);

#endif
