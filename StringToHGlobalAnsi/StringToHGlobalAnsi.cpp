// StringToHGlobalAnsi.cpp: 定义控制台应用程序的入口点。
//
#include "stdafx.h"
#include <iostream>
#include <vcclr.h>
using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;

#pragma unmanaged
void GetStrFromManage(char* msg)
{
	printf_s(msg);
}

#pragma managed
void GetStrFromUnmanage(char* msg)
{
	String^ s = Marshal::PtrToStringAnsi(static_cast<IntPtr>(msg));
	Console::WriteLine(s);
}

#pragma unmanaged
void NativeProvidesAString() {
	cout << "(native) calling managed func...\n";
	char* s = (char*)("sssssss");
	GetStrFromUnmanage(s);
}

#pragma managed
int main()
{
	//String^ s = gcnew String("Hello from managed");
	//IntPtr p = Marshal::StringToHGlobalAnsi(s);
	//char* msg = static_cast<char*>(p.ToPointer());
	//Console::WriteLine("{0} start.....",s);
	//GetStrFromManage(msg);
	//Marshal::FreeHGlobal(p);


	NativeProvidesAString();
	Console::ReadKey();
    return 0;
}

