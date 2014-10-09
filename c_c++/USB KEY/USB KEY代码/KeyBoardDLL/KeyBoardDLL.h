#ifndef __KEYBOARDDLL_H
#define __KEYBOARDDLL_H

#ifdef KEYBOARDDLL_EXPORTS
#define KEYBOARDDLL_API extern "C" __declspec(dllexport)
#else
#define KEYBOARDDLL_API extern "C" __declspec(dllimport)
#endif

KEYBOARDDLL_API LRESULT CALLBACK MyTaskKeyHookLL(int nCode, WPARAM wp, LPARAM lp);
KEYBOARDDLL_API BOOL DisableTaskKeys(BOOL bDisable, BOOL bBeep);
KEYBOARDDLL_API BOOL AreTaskKeysDisabled();

#endif
