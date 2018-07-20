#include "TestUnmanagedDllcpp.h"
#pragma managed
#pragma make_public
namespace MyCliDll {

	MyCliDll::MyCliCLass::MyCliCLass()
	{

	}
	MyCliDll::MyCliCLass::~MyCliCLass()
	{

	}

	bool MyCliDll::MyCliCLass::GetResult1(String^* res)
	{
		IntPtr p = Marshal::StringToHGlobalAnsi(*res);
		char* s = static_cast<char*>(p.ToPointer());
		bool bRet = GetResult(&s);
		Marshal::FreeHGlobal(p);
		return bRet;
	}

	int MyCliDll::MyCliCLass::Add(int x, int y)
	{
		return x + y;
	}
}