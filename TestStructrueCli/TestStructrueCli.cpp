// TestStructrueCli.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>

using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;
/*
下面的示例演示如何按值以及按引用从托管函数向非托管函数传递结构。 
由于本示例中的结构只包含简单内部数据类型（请参见 可直接复制到本机结构中的类型和非直接复制到本机结构中的类型），
因此不需要进行特殊的封送处理。 若要封送非直接复制到本机结构中的结构（例如包含指针的结构），
请参见 如何：使用 C++ 互操作封送嵌入式指针。
*/
#pragma unmanaged
struct Pos
{
	Pos(int _x,int _y)
	{
		x = _x;
		y = _y;
	}
	int x;
	int y;
};
double GetDistanse(Pos pos1, Pos pos2)
{
	return sqrt(pow((pos1.x - pos2.x), 2) + pow((pos1.y - pos2.y), 2));
}
void InitLocation(Pos* pos)
{
	pos->x = 50;
	pos->y = 50;
}

#pragma managed
int main()
{
	Pos p1(0,0), p2(300,40);
	InitLocation(&p1);
	double d=GetDistanse(p1, p2);
	Console::WriteLine("The distanse is: {0}",Math::Round(d,3));
	Console::ReadKey();
    return 0;
}

