package PTESTF;

public class test1
{
	public static void main(String[] args)
	{
		String str="中国人有颗中国心！中国 十分的中国说法";		
		int n = str.indexOf("中国") ;
		int index = 0 ;
		while(-1 != n)
		{
			index ++;
			n =  str.indexOf("中国",n+1);
		}

		System.out.println(index);
	}
}