#include <Windows.h>

BOOL WINAPI DllMain(
	HINSTANCE hinstDLL,  // handle to DLL module
	DWORD fdwReason,     // reason for calling function
	LPVOID lpReserved)  // reserved
{
	// Perform actions based on the reason for calling.
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		// Initialize once for each new process.
		// Return FALSE to fail DLL load.
		break;

	case DLL_THREAD_ATTACH:
		// Do thread-specific initialization.
		break;

	case DLL_THREAD_DETACH:
		// Do thread-specific cleanup.
		break;

	case DLL_PROCESS_DETACH:
		// Perform any necessary cleanup.
		break;
	}
	return TRUE;  // Successful DLL_PROCESS_ATTACH.
}
extern "C" _declspec(dllexport) bool GetResult(int x,char* pBuf)
{
	//pBuf = (char*)"Get form C++";
	//strcpy_s(pBuf, strnlen_s("Get form C++", 20), "Get form C++");
	if(x==1)
		strncpy_s(pBuf, 20, "Get form C++", 20);
	else
		strncpy_s(pBuf, 20, "No.....", 20);

	return x == 1;
}

