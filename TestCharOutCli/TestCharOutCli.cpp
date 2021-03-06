// TestCharOutCli.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>

using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;

#pragma unmanaged
void GetResult(wchar_t** result)
{
	*result = (wchar_t*)L"中文Hello Form unmanaged";
}

#pragma managed
void Use(String^* s)
{
	Console::WriteLine(*s);
	IntPtr p = Marshal::StringToHGlobalUni(*s);
	wchar_t* ss = static_cast<wchar_t*>(p.ToPointer());
	GetResult(&ss);
	*s=Marshal::PtrToStringUni(((IntPtr)ss));
	Console::WriteLine(*s);
	Marshal::FreeHGlobal(p);
}


#pragma managed
int main()
{
	String^ s = gcnew String("hello");
	Use(&s);
	Console::WriteLine(s);
	Console::ReadKey();
    return 0;
}

