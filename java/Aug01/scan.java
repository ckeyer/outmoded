//关于键盘输入的获取 
import java.util.Scanner;
public class scan
{
	public static void main(String[] args)
	{
		Scanner in=new Scanner(System.in);
		System.out.print("Enter your name:");
		String name=in.next();
		System.out.print("Enter your age:");
		int age=in.nextInt();
		System.out.print("name:"+name+"\n");
		System.out.print("age:"+age);
	}
}
