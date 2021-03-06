// CliUnicodeString.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;

#pragma unmanaged
void NativeTakesAString(wchar_t* msg)
{
	std::wcout.imbue(std::locale("chs"));	//不加这句无法显示中文，不知道为什么
	wcout << msg << endl;
}

#pragma managed
void ManagedStringFunc(wchar_t* wString)
{
	String^ s = Marshal::PtrToStringUni((IntPtr)wString);
	Console::WriteLine("{0}", s);
}

#pragma unmanaged
void NativeProvidesAString()
{
	ManagedStringFunc((wchar_t*)_T("中文"));
}

#pragma managed
int main()
{
	//String^ s = gcnew String("中文");
	//IntPtr p= Marshal::StringToHGlobalUni(s);
	//wchar_t* pwString = static_cast<wchar_t*>(p.ToPointer());
	//NativeTakesAString(pwString);
	//Marshal::FreeHGlobal(p);

	NativeProvidesAString();
	Console::ReadKey();
    return 0;
}

