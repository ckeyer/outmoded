/****************************************
	文件名：wcj_1.h
	实现：编程实现单链表的创建、插入和删除操作
	作者：CJ_Studio
	创建时间：2014/3/23 下午
*****************************************/

#include <stdio.h>

#define nil NULL

typedef struct Node
{
	int data;
	struct Node *next;
}Node,*pNode;

void show(Node node)
{
	printf("%d\n", node.data);
}

// 按序显示链表p_n的所有数据
void showAll(pNode p_node)
{
	show(*p_node);
	while(p_node->next != nil) {
		p_node = p_node->next;
		show(*p_node);
	}
}

// 在链表PN末尾处插入p_n节点或链表
void addNodeAtLast(pNode p_n,pNode PN)
{
	pNode tmpPN = PN;
	while(tmpPN->next != nil) {
		tmpPN = tmpPN->next;
	}
	tmpPN->next = p_n;
}

// 在链表PN当前位置插入p_n节点或链表
void addNodeAtHere(pNode p_n,pNode PN)
{
	pNode tmp = PN->next;
	PN->next = p_n;
	while(p_n->next != nil) {
		p_n = p_n->next;
	}
	p_n->next = tmp;
}

// 在链表PN的index位置之前插入p_n节点或链表
void addNodeByIndex(pNode p_n,int index,pNode PN)
{
	pNode tmpPN = PN;
	if(0==index) {
		PN=p_n;
		while(p_n->next != nil) {
			p_n = p_n->next;
		}
		p_n->next = tmpPN;
	}else{
		int i=1;
		while(tmpPN->next != nil && i<index) {
			tmpPN = tmpPN->next;
			i++;
			if(i==index) break;
		}

		pNode tmp = tmpPN->next;
		tmpPN->next = p_n;
		while(p_n->next != nil) {
			p_n = p_n->next;
		}
		p_n->next = tmp;
	}
}

void deleteByIndex(pNode PN,int index)
{
	if(0==index) {
		PN=PN->next;
	}
	else {
		pNode tmpPN = PN;
		int i=1;
		while(tmpPN->next != nil && i<index) {
			tmpPN = tmpPN->next;
			i++;
			if(i==index) break;
		}
		tmpPN->next = tmpPN->next->next;
	}
}