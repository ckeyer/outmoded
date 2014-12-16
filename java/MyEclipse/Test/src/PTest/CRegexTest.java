package PTest;

import java.util.Scanner;

public class CRegexTest implements ITest{
	public void test()
	{
		Scanner console = new Scanner(System.in);
		while(true)
		{
			System.out.print("ÊäÈë×ø±ê£º");
			String location = console.nextLine();
			String reg = "^\\d+[,\\s]\\s*\\d+$";
			if(location.matches(reg))
			{
				String[] data = location.split("[,\\s]\\s*");
				int x = Integer.parseInt(data[0]);
				int y = Integer.parseInt(data[1]);
				System.out.println(x + "," + y);
				return;
			}
		}
	}

}
