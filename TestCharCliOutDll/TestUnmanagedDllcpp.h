#pragma once
#include <iostream>
using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;
#pragma comment(lib,"MyDll.lib")
extern "C" _declspec(dllimport) bool GetResult(char** result);
#pragma managed
namespace MyCliDll
{

	public ref class MyCliCLass
	{
	public:
		MyCliCLass();
		~MyCliCLass(); 
		bool __clrcall GetResult1(String^* res);
		int __clrcall Add(int x, int y);
	};
}