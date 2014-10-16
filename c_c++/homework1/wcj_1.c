/****************************************
	文件名：wcj_1.c
	实现：编程实现单链表的创建、插入和删除操作
	作者：CJ_Studio
	创建时间：2014/3/23 下午
*****************************************/

#include "wcj_1.h"

	struct Node myNode;

int main()
{
	myNode.data = 1111;

	Node t1,t2,t3;
	t1.data = 2222;
	t1.next = nil;
	t2.data = 3333;
	t2.next = nil;
	t3.data = 4444;
	t3.next = nil;
	showAll(&myNode);

	printf("插入1：\n");
	addNodeAtHere(&t2,&myNode);
	showAll(&myNode);

	printf("插入2：\n");
	addNodeAtLast(&t1,&myNode);
	showAll(&myNode);

	printf("插入3：\n");
	addNodeByIndex(&t3,2,&myNode);
	showAll(&myNode);

	printf("删除：\n");
	deleteByIndex(&myNode,2);
	showAll(&myNode);
	return 0;
}