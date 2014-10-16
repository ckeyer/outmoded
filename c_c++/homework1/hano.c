 #include "stdio.h" 

void hanoi(int,char,char,char); 

int main() 
{
	int n;
	printf("输入盘子数："); 
	scanf("%d",&n); 
	hanoi(n,'A','B','C'); 
	return 0;
} 
 
void hanoi(int n,char a,char b,char c) 
{
	if(n>1)
	{
		hanoi(n-1,a,c,b); 
		printf("%c-->%c\n",a,c);
		hanoi(n-1,b,a,c); 
	}	
	else 
	{
		printf("%c-->%c\n",a,c);
	}
}
