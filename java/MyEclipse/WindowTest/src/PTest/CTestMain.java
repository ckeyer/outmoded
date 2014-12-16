package PTest;

import java.util.Scanner;

public class CTestMain
{
	
//	public static void main(String[] args)
//	{
//		double r,h;
//		Scanner scan = new Scanner(System.in);
//		System.out.print("输入圆柱体的底面半径：");
//		r = scan.nextDouble();
//		System.out.print("输入圆柱体的高：");
//		h = scan.nextDouble();
//		System.out.println("该圆柱体的体积为：" + Math.PI *r *r *h);
//		
//	}
	
	public static void main(String argv[])
	{
		for(int i=0;i<34;i++)//大马最多33匹 
			for(int j=0;j<51;j++)//小马最多50匹 
				for(int k=0;k<101;k++)//马驹最多100匹,因为总数限制 
				{ 
					if ((i*3+j*2+k/2)==100 && (i+j+k)==100 )//条件判断,是否满足 
							System.out.println("答案是：大马"+i+"匹,中马"+j+"匹,马驹"+k+"匹。" ); 
				} 
	}
}
