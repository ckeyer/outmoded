#include <stdio.h>
#define   A  100

int max(int a,int b)
{
 	return  a> b?a+A:b+A;
}
int main()
{  int i=2,j=3;
	int max (int,int);
	printf("i+A=%d\n",i+A);
	printf("max=%d\n",max(i,j));
	#undef  A
	#define  A  10
	printf("i+A=%d\n",i+A);
	printf("max=%d\n",max(i,j));
	return 0;
}


