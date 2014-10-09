//贪吃蛇双人PK版，威威制作于 2012.11.17
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<conio.h>
#include<windows.h>
#define SPEED 500

#define LEN sizeof(struct snakeNode)
struct snakeNode //蛇身，循环链
{
	int x, y;
	struct snakeNode * next;
};
typedef struct snakeHead //蛇头，指向蛇尾
{
	int player, direction;
	int x, y;
	struct snakeNode * tail;
}snake;

void gotoxy(int x, int y)
{
	COORD c;
	c.X = 2 * x, c.Y = y; //本游戏只使用双字节符号
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
}

void welcome(void)
{
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐              ┌─┐                                                └┬┴");
	printf("┴┬┘            ┌┴┬┘                                                ┌┴┬");
	printf("┬┴┐            └─┘  Welcome to the Snake game!  ┌─┐              └┬┴");
	printf("┴┬┘          /^\\/^\\                              ┌┴┬┴┐            ┌┴┬");
	printf("┬┴┐        _|__|  O|                             └─┴─┘          ┌┴┬┴");
	printf("┴┬┘ \\/   /~     \\_/ \\                                                └┬┴┬");
	printf("┬┴┐  \\__|__________/ \\                     \\                           └┬┴");
	printf("┴┬┘      \\________    \\                     \\\\                         ┌┴┬");
	printf("┬┴┐               `\\   \\                     \\ \\                     ┌┴┬┴");
	printf("┴┬┘                |   |          ___         \\  \\                   └┬┴┬");
	printf("┬┴┐               /   /        _-~   ~-_     _/   |                    └┬┴");
	printf("┴┬┘              (   (      _-~    __   ~-_-~    /                     ┌┴┬");
	printf("┬┴┐               \\   ~-__-~    _-~  ~-_      _-~          ┌───╖  └┬┴");
	printf("┴┬┘                ~-_       _-~        ~-__-~             │      ║  ┌┴┬");
	printf("┬┴┐                   ~-___-~                              │      ║  └┬┴");
	printf("┴┬┘             ┌────────╖                 ┌──┘      ║  ┌┴┬");
	printf("┬┴┐ [查看说明]按│      空格      ║   [开始游戏]请按│Enter ←─┘║  └┬┴");
	printf("┴┬┘             ╘════════╝                 ╘══════╝  ┌┴┬");
	printf("┬┴┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	system("title 贪吃蛇 - 双人版");
	gotoxy(0, 0);
}

void explain(void)
{
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐              ┌─┐                                                └┬┴");
	printf("┴┬┘            ┌┴┬┘                                                ┌┴┬");
	printf("┬┴┐            └─┘       ☆贪吃蛇的说明☆       ┌─┐              └┬┴");
	printf("┴┬┘【控制说明】                                  ┌┴┬┴┐            ┌┴┬");
	printf("┬┴┐                                              └─┴─┘          ┌┴┬┴");
	printf("┴┬┘    玩家1：字母键W, S, A, D 分别控制上、下、左、右。              └┬┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘    玩家2：方向键↑ ↓ ← →控制上下左右。    [F1键 暂停]           ┌┴┬");
	printf("┬┴┐                                                                  ┌┴┬┴");
	printf("┴┬┘【胜利条件】                                                      └┬┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘    当一名玩家的蛇头撞到墙或蛇身后死亡，则另一名玩家胜利。          ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐ps:这是我第一次用C语言制作的小游戏，不好做呐，下次要用另一种语言做哦└┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐      玩家1：●●⊙      玩家2：○○◎       食物：☆               └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	gotoxy(0, 0);
}

void gameover(int player)
{	
	system("color 07");
	gotoxy(0, 0);
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └─┘  └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐              ┌─┐                                                └┬┴");
	printf("┴┬┘            ┌┴┬┘                                                ┌┴┬");
	printf("┬┴┐            └─┘         ☆游戏结束☆         ┌─┐              └┬┴");
	printf("┴┬┘                                              ┌┴┬┴┐            ┌┴┬");
	printf("┬┴┐                                              └─┴─┘            └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘             ┌──╖                                               ┌┴┬");
	printf("┬┴┐           按│ESC ║ 退出游戏，按任意键继续游戏...                 └┬┴");
	printf("┴┬┘             ╘══╝                                               ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘                                   感谢您玩本游戏^_^ CJ工作室       ┌┴┬");
	printf("┬┴┐                                                                    └┬┴");
	printf("┴┬┘                                                                    ┌┴┬");
	printf("┬┴┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌─┐  ┌┴┬┴");
	printf("┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬");
	printf("┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴┬┴");
	gotoxy(11, 11);
		 if(player == 3) printf("☆平局哦：⊙●●●●  ◎○○○○");
	else if(player == 1) printf("◎胜利者是：玩家2 ◎○○○○○○");
	else if(player == 2) printf("⊙胜利者是：玩家1 ⊙●●●●●●");
	gotoxy(11, 13);
}

void initialize(snake * p1, snake * p2, int g[][25])
{
	int i, j;
	gotoxy(0, 0);			//初始化界面
	printf("┬┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴");
	for(i=0; i<23; i++)
		if(i % 2) printf("┐%76c└", ' ');
		else printf("┘%76c┌", ' ');
	printf("┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬┴");

	for(i=0; i<40; i++)		//初始化网格
	{
		for(j=0; j<25; j++)
			if(i==0 || i==39 || j==0 || j==24)
				g[i][j] = 4;
			else
				g[i][j] = 0;
	}

	struct snakeNode * p;
	p1->x = 13, p1->y = 12, g[13][12] = 1;		//蛇1
	gotoxy(p1->x, p1->y), printf("⊙");
	p = (struct snakeNode *)malloc(LEN);
	p->x = 13, p->y = 13, g[13][13] = 1;
	gotoxy(p->x, p->y),  printf("●");
	p1->tail = p, p->next = p;

	p2->x = 26, p2->y = 12, g[26][12] = 2;		//蛇2
	gotoxy(p2->x, p2->y), printf("◎");
	p = (struct snakeNode *)malloc(LEN);
	p->x = 26, p->y = 13, g[26][13] = 2;
	gotoxy(p->x, p->y),  printf("○");
	p2->tail = p, p->next = p;

	gotoxy(19, 12), printf("准备..."), gotoxy(0, 0), Sleep(500);
	gotoxy(19, 12), printf("       "), gotoxy(0, 0), Sleep(100);
	gotoxy(19, 12), printf("三..."), gotoxy(0, 0), Sleep(500);
	gotoxy(19, 12), printf("     "), gotoxy(0, 0), Sleep(100);
	gotoxy(19, 12), printf("二..."), gotoxy(0, 0), Sleep(500);
	gotoxy(19, 12), printf("     "), gotoxy(0, 0), Sleep(100);
	gotoxy(19, 12), printf("一..."), gotoxy(0, 0), Sleep(500);
	gotoxy(19, 12), printf("     "), gotoxy(0, 0), Sleep(100);
	gotoxy(19, 12), printf("开始！"), gotoxy(0, 0), Sleep(500);
	gotoxy(19, 12), printf("      "), gotoxy(0, 0), Sleep(100);

	while(kbhit()) getch(); //清除开始游戏前的所有输入
	srand(time(NULL)); //播下随机种子
}

void keyboard(char k, int * d1, int * d2, int * s)
{
	if(k == 0) //暂停游戏
	{
		while(getch() != 0);
		getch();
	}
	if(*s != 1)
	{
			 if(k == 'w' && *d1 != 3) *d1 = 1, *s += 1;
		else if(k == 'd' && *d1 != 4) *d1 = 2, *s += 1;
		else if(k == 's' && *d1 != 1) *d1 = 3, *s += 1;
		else if(k == 'a' && *d1 != 2) *d1 = 4, *s += 1;
	}
	if(*s != 2)
	{
			 if(k == 72 && *d2 != 3) *d2 = 1, *s += 2;
		else if(k == 77 && *d2 != 4) *d2 = 2, *s += 2;
		else if(k == 80 && *d2 != 1) *d2 = 3, *s += 2;
		else if(k == 75 && *d2 != 2) *d2 = 4, *s += 2;
	}
}

void createfood(int g[][25])
{
	int x, y;
	do
	{
		x = rand() % 38 + 1;
		y = rand() % 23 + 1;
	}while(g[x][y]);
	g[x][y] = 3;
	gotoxy(x, y), printf("☆");
}

int move(snake * head, int g[][25])
{
	struct snakeNode * p;
	int x = head->x, y = head->y;
	int food = 0;

		 if(head->direction==1) (head->y)--; //蛇头移动
	else if(head->direction==2) (head->x)++;
	else if(head->direction==3) (head->y)++;
	else if(head->direction==4) (head->x)--;

	if(g[head->x][head->y] == 3) //吃了东西
	{
		p = (struct snakeNode *)malloc(LEN);
		p->x = x, p->y = y;
		p->next = head->tail->next;
		head->tail->next = p;
		food = 1;
	}
	else if(g[head->x][head->y]) //游戏结束
	{
		system("color 40");
		p = head->tail;
		while(p->next != head->tail)
		{
			gotoxy(p->x, p->y), printf("×");
			p = p->next;
			Sleep(100);
		}
		gotoxy(p->x, p->y), printf("×");
		Sleep(2000);
		while(kbhit()) getch(); //清除进入死亡界面前的所有输入
		return 4;
	}
	else //正常移动
	{
		p = head->tail;
		gotoxy(p->x, p->y), printf("  ");
		g[p->x][p->y] = 0;
		p->x = x, p->y = y;
		do
		{
			p = p->next;
		}while(head->tail != p->next);
		head->tail = p;
	}

	gotoxy(head->x, head->y);
	if(head->player==1) printf("⊙");
	else printf("◎");
	gotoxy(x, y);
	if(head->player==1) printf("●");
	else printf("○");

	g[head->x][head->y] = head->player;
	return food;
}


int main() //●⊙◎○☆
{
	int gridding[40][25]; //值0表示空地，值1表示蛇1，值2表示蛇2，值3表示食物，值4表示障碍物
	int snake1, snake2;   //值0表示正常，值1表示吃了东西，值4表示死亡
	int keySwitch, grade, speed, win1 = 0, win2 = 0;
	char key = 0;
	clock_t millisecond;
	snake p1, p2;
	
	welcome(); //开始画面，Enter进入游戏，空格则进入说明界面
	while(key != 13 && key != 32) key = getch();
	if(key == 32) explain(), getch();

	do
	{
		p1.player = 1, p1.direction = 1; //初始化数据
		p2.player = 2, p2.direction = 1;
		keySwitch = 0, grade = 0, speed = 150, snake1 = 0, snake2 = 0;
		initialize(&p1, &p2, gridding);
		createfood(gridding), grade++;
		millisecond = clock();

		while(snake1 != 4 && snake2 != 4)
		{
			if( kbhit() )
			{
				key = getch();
				if(key == 224) key = getch();
				if(keySwitch < 3) //让蛇在移动一步前，不接受两种不同方向指令的策略
				{
					keyboard(key, &(p1.direction), &(p2.direction), &keySwitch);
				}
			}
			else if(clock() - millisecond > speed)
			{
				snake1 = move(&p1, gridding);
				snake2 = move(&p2, gridding);
				if(snake1 == 4 || snake2 == 4) break; 
				else if(snake1 ==1 || snake2 ==1) createfood(gridding), grade++;
				snake1 = 0, snake2 = 0, keySwitch = 0;
				if(grade == 10)
				{
					grade++;
					speed = 60;
					system("color 0F"), Sleep(500);
					system("color 07"), Sleep(300);
					system("color 0F"), Sleep(300);
				}
				else if(grade == 15)
				{
					grade++;
					speed = 80;
					system("color 0E");
				}
				else if(grade == 30)
				{
					grade++;
					speed = 100;
					system("color 0B");
				}
				else if(grade == 40)
				{
					grade++;
					speed = 120;
					system("color 0D");
				}
				else if(grade == 60)
				{
					grade++;
					speed = 90;
					system("color 0C"), Sleep(500);
					system("color 0D"), Sleep(300);
					system("color 0C"), Sleep(300);
				}
				millisecond = clock();
			}
		}

		struct snakeNode * pp1, * pp2; //游戏结束，清除两条蛇链
		pp1 = p1.tail->next;
		while(p1.tail != pp1)
		{
			pp2 = pp1->next;
			free(pp1);
			pp1 = pp2;
		}
		free(p1.tail);
		pp1 = p2.tail->next;
		while(p2.tail != pp1)
		{
			pp2 = pp1->next;
			free(pp1);
			pp1 = pp2;
		}
		free(p2.tail);

		if(snake1 == 4 && snake2 == 4) gameover(3); //结束界面
		else if(snake1 == 4) gameover(1), win2++;
		else if(snake2 == 4) gameover(2), win1++;
		printf("[玩家1胜利%d局] VS [玩家2胜利%d局]", win1, win2);
		gotoxy(0, 0);

		if(getch()==27) exit(0); //选择继续玩或退出
	}while(1);
}

//所涉及到的函数说明
/* 
<conio.h>
int getch(void)
	从控制台读取一个字符，但不显示在屏幕上，返回读取的字符。
int kbhit(void)
	检查当前是否有键盘输入，若有则返回一个非0值，否则返回0。

<time.h>
time_t time(time_t *timer)
	得到机器的日历时间或者设置日历时间。
	timer=NULL时得到机器日历时间，timer=时间数值时，用于设置日历时间，time_t是一个long类型。
clock_t clock(void)
　　得到从程序启动到此次函数调用时累计的毫秒数。

<windows.h>
Sleep(unsigned long)
	程序暂停若干时间，单位是毫秒。注意第一个字母是大写。

<stdlib.h>
void srand(unsigned int)
	播种子，使用相同的种子后面的rand()函数会出现一样的随机数。真随机：srand(time(NULL));
int rand()
	生成0~RAND_MAX之间的一个随机数（按指定的顺序来产生）。
*/

/*
//随意控制输入位置的方法
#include<windows.h>

void gotoxy(int x, int y) {
COORD c;
c.X = x - 1;
c.Y = y - 1;
SetConsoleCursorPosition (GetStdHandle(STD_OUTPUT_HANDLE), c);
}

int main()
{ 
return 0;
}
其中的COORD和SetConsoleCursorPosition定义在wincon.h上
SetConsoleCursorPosition用于在相应的设备设置光标的位置，两个参数分别是设备句柄和光标位置结构
GetStdHandle定义在winbase.h上用于获得标准输入、输出、错误输出句柄
当参数标识为STD_OUTPUT_HANDLE时获得标准输出句柄
*/