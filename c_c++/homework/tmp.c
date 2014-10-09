void inorder(BiTree root)
{
	SeqStack S;//定义一个栈
	InitStack(&S);//初始化这个栈为空
	BiTree p;
	p=root;
	while(p!=NULL||!IsEmpty(&S))
	{
		if(p!=NULL)
		{
		Push(&S,p);
		p=p->LChild;
		}//根指针进栈，遍历左子树
		else
		{
			printf("-");
			Pop(&S,&p);
			printf("%c",p->data);
			p=p->RChild;
		}//根指针退栈，输出根节点，遍历右子树
	}
}