#include "stdafx.h"

#include "stdio.h"

void sample()
{
    int x = 10;
    int& r = x; // x �̎Q�Ƃ����

    r = 99; // �Q�ƌ��� x �����������

    printf("%d", x); // 99
}

int _tmain(int argc, _TCHAR* argv[])
{
    sample();
	return 0;
}

