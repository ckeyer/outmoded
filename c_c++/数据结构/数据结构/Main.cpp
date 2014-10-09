/****************************************************
 
 ***** 名称：    数据结构上级习题
 ***** 作者：    CJ工作室 
 ***** 创建时间：2012年11月9日

*****************************************************/

#include "hMybase.h"

void interwin();
void clockend(clock_t begin);
int mainmenu();
int menuA();
int menuB();
int menuC();
int menuD();
int menuE();
clock_t begin;

int main()
{
	interwin();
	begin=clock();

	mainmenu();		//菜单函数入口

	clockend(begin);	//结束函数
	return 0;
}

//主菜单函数
int mainmenu()
{
	
	int i;
	char input='y';
	char me1='1';
	char me2='a';
	system("cls");
	system("color 1f");
	P("\t\t***************************************\n");
	P("\t\t*******      数据结构实验       *******\n");
	P("\t\t***************************************\n\n");
	P("\t\t%c.单链表实验\n",me1);me1++;
	 P("\t\t\t%c.\n",me2);me2++;
	P("\t\t%c.栈的实验\n",me1);me1++;
	 
	P("\t\t%c.串实验\n",me1);me1++;
	 
	P("\t\t%c.二叉树实验\n",me1);me1++;
	printf("\n\t\t\t\t保存 请按 Cirl+S 键！！！\n");
	printf("\t\t\t\t退出 请按 ESC 键！！！\n");
	 

	system("pause");
	return 0;
}

//单链表
int menuA()
{
	return 0;
}

//栈
int menuB()
{
	return 0;
}

//串
int menuC()
{
	return 0;
}

//二叉树
int menuD()
{
	return 0;
}

//
int menuE()
{
	return 0;
}

//主函数计时及退出界面函数
void clockend(clock_t begin)
{
	int i;
	system("cls");
	system("color 02");
	clock_t end;
	time_t cost,ntime;
	struct tm *ctm ,*ntm;
	ntime=time(NULL);
	ntm=localtime(&ntime);
	printf("\n现在是：%4d年%2d月%2d日  %d时%d分%02d秒\n",ntm->tm_year+1900,ntm->tm_mon+1,ntm->tm_mday,ntm->tm_hour, ntm->tm_min,ntm->tm_sec);
	end=clock();
	cost=(int)(end-begin)/ 1000;
	ctm=localtime(&cost);
	Sleep(200);
	printf("\n操作用时：%d分%02d秒\n", ctm->tm_min,ctm->tm_sec);
	Sleep(200);
	printf("\n谢谢使用");
	for(int i=1;i<6;i++)
	{
		Sleep(250);
		printf("\a!");
	}
	printf("\n");
	Sleep(800);
	exit(0);
}

//主界面进入函数
void interwin()
{
	int i;
	system("color 02");
	P("\n\n\n\n\n");
	P("\a\t\t***************************************\n");
	P("\t\t***                                 ***\n");
	P("\t\t***   数据结构 V1.0                 ***\n");
	P("\t\t***                                 ***\n");
	P("\t\t***   CJ工作室                      ***\n");
	P("\t\t***                                 ***\n");
	P("\t\t***   2012年11月11日                ***\n");
	P("\t\t***                                 ***\n");
	P("\t\t***************************************\n\n\n\n\n\a");
	for(i=1;i<40;i++)
	{
		printf("--");
	};
	Sleep(500);
	printf("\r");
	for(i=1;i<40;i++)
	{
		Sleep(40);
		printf(" >");
	};
	printf("\n\n\n");
	system("pause");
}