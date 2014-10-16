
/****************************************
	文件名：wcj_2.c
	实现：编程实现二叉树的创建
		 编程实现二叉树的三种遍历
	作者：CJ_Studio
	创建时间：2014/3/23 下午
*****************************************/
#include <stdio.h>

typedef struct Tree
{
	int data;
	struct Tree	*Left;
	struct Tree	*Right;
}Tree,*pTree;

void initNode(pTree p,int n)
{
	p->Left = NULL;
	p->Right = NULL;
	p->data = n;
}

void addLeaf(pTree root,pTree left,pTree right)
{
	root->Right = right;
	root->Left = left;
}

void PreOrder(Tree root)
{
	printf("%d\n", root.data);
	if(NULL != root.Left)
		PreOrder(*(root.Left));
	if(NULL != root.Right)
		PreOrder(*(root.Right));
}

void InOrder(Tree root)
{
	if(NULL != root.Left)
		InOrder(*(root.Left));
	printf("%d\n", root.data);
	if(NULL != root.Right)
		InOrder(*(root.Right));
}

void PostOrder(Tree root)
{
	if(NULL != root.Left)
		PostOrder(*(root.Left));
	if(NULL != root.Right)
		PostOrder(*(root.Right));
	printf("%d\n", root.data);
}

int main(){
	Tree root,t1,t2,t3;
	initNode(&root,1);
	initNode(&t1,2);
	initNode(&t2,3);
	initNode(&t3,4);
	addLeaf(&root,&t1,NULL);
	addLeaf(&t1,&t2,&t3);
	printf("先序遍历:\n");
	PreOrder(root);
	printf("中序遍历:\n");
	InOrder(root);
	printf("后序遍历:\n");
	PostOrder(root);
	return 0;
}
