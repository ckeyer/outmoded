#include <stdio.h>
#include <stdlib.h>

typedef struct List_Node{
	int info;
	struct List_Node *next;
}node; 

 //链表长度
int len(node *head)
{
	node *p;
	
	int num=0;
	if (head ==NULL)
	{
		return 0;
	}
	p=head->next;
	while(p!=NULL)
	{
		num++;
		p=p->next;
	}
	return num;
}

//插入元素 
void InsertItem(node *head, int loc, int num)
{
	node *p, *pre, *s;
	int i=0;
	if (loc>len(head)||loc<0)
	{
		printf("插入位置错误\n");
		return;
	}
	if (head == NULL)
	{
		return;
	}
	pre=head;
	p = head->next;
	while(i!=loc)
	{
		i++;
		pre = p;
		p=p->next;
	}
	s=(node*)malloc(sizeof(node));
	s->info=num;
	s->next=p;
	pre->next=s;
}

//删除元素 
int deleteItem(node *head, int loc)
{
	node *p, *pre;
	int i=1, num=0;
	if (loc>len(head)||loc<=0)
	{
		printf("删除位置错误\n");
		return 0;
	}
	if (head == NULL)
	{
		return 0;
	}
	pre=head;
	p = pre->next;
	while(i!=loc)
	{
		i++;
		pre = p;
		p=p->next;
	}
	num = p->info;
	pre->next = p->next;
	p->next = NULL;
	free(p);
	return num;
}


//尾插法建立带头结点的单链表
node* Creat_Node()
{
	node *head,*pre,*p;
	int x;
	head=(node*)malloc(sizeof(node));;
	head->next=NULL;
	pre=head;
	printf("输入各结点的值,以0结束:");
	while(EOF!=(scanf("%d",&x))&&x!=0)
	{
		p=(node*)malloc(sizeof(node));
		p->info=x;
		p->next=pre->next;
		pre->next=p;
		pre=pre->next;
	}
	return head;
}

//在Y前插入X
void Before_y_Insert_x(node* head,int y,int x)
{
	node *pre,*p,*s;
	if (head ==NULL)
	{
		return;
	}
	pre=head;
	p=pre->next;
	while(p&&p->info!=y)
	{
		pre=p;
		p=p->next;
	}
	if(p==NULL)
	{
		printf("error!%d不在该链表中\n",y);
	}
	else
	{
		s=(node*)malloc(sizeof(node));
		s->info=x;
		s->next=p;
		pre->next=s;
	}
}


//打印单链表
void Print_Node(node *head)
{
	node *p;
	if (head ==NULL)
	{
		return;
	}
	p=head->next;
	printf("输出该链表:\n");
	while(p)
	{
		printf("%d\n",p->info);
		p=p->next;
	}
}

void menu()
{
	printf("a:创建链表\n");
	printf("b:在Y前插入X \n");
	printf("c:插入元素\n");
	printf("d:删除元素\n");
	printf("e:打印链表\n");
	printf("f:退出\n");
}

int main()
{
	
	int goon = 1;
	node *head=NULL,*head1=NULL,*head2=NULL;
	int x=0, y=0;
	int flag = 0;
	char choice;
	menu();
	while(goon)
	{
		printf("请选择：\n");
		scanf("%c",&choice);
		switch (choice)
		{
		case '0':
			menu();
			break;
		case 'a':
		case 'A':
			printf("创建链表\n");
			head=Creat_Node();
			break;
		
		case 'b':
		case 'B':
			printf("在Y前插入X\n请输入X和Y:\n");
			scanf("%d%d",&x,&y);
			Before_y_Insert_x(head,y,x);
			break; 
	
		case 'c':
		case 'C':
			printf("插入元素\n请输入插入的位置（0到链表长度之间）和元素");
			scanf("%d%d",&x,&y);
			InsertItem(head,x,y);
			break;

		case 'd':
		case 'D':
			printf("删除元素\n请输入删除元素的位置（1到链表长度之间）");
			scanf("%d",&x);
			printf("删除的元素为%d",deleteItem(head,x));
			break;
		
		case 'e':
		case 'E':
			Print_Node(head);
			break;

		case 'f':
		case 'F':
			printf("Exit!");
			return 0;

		default:
			break;
		}
	}
	return 0;    
}