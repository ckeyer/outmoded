
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the MOUSEDLL_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// MOUSEDLL_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef MOUSEDLL_EXPORTS
#define MOUSEDLL_API extern "C" __declspec(dllexport)
#else
#define MOUSEDLL_API extern "C"__declspec(dllimport)
#endif

// This class is exported from the MouseDLL.dll
//class MOUSEDLL_API CMouseDLL {
//public:
//	CMouseDLL(void);
	// TODO: add your methods here.
//};

//extern MOUSEDLL_API int nMouseDLL;

MOUSEDLL_API int fnMouseDLL(void);

MOUSEDLL_API BOOL EnableMouseLock();
MOUSEDLL_API BOOL DisableMouseLock();

