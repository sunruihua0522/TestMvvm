// TestArray.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <stdlib.h>  
#include <vcclr.h>  
using namespace std;
using namespace System;
#pragma unmanaged
void setArr(int* arr, int nLen)
{
	for (int i = 0; i < nLen; i++)
		*(arr++) = i;
}
void setString(char* pBuf)
{
	printf_s(pBuf);
}


#pragma managed


int main()
{
	array<int>^ arr = gcnew array<int> (5);
	for(int i=0;i<arr->Length;i++)
	{
		arr[i] = 99;
	}
	pin_ptr<int> pt = &arr[0];
	setArr(pt, 5);
	for (int i = 0; i < arr->Length; i++)
		Console::WriteLine(arr[i].ToString());

	String^ ss = gcnew String("Hello");
	//pin_ptr<const char> pStr =PtrToStringChars(ss);
    return 0;
}

