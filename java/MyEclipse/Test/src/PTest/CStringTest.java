package PTest;

public class CStringTest implements ITest{
	
	public void test()	// main();
	{
		int times = 1000000;
		System.out.println(AddStringBuilder(times) + "  PK  " + AddChar(times));
//		System.out.println(AddStringBuilder(times) + "  PK  " + AddStringBuilder2(times));
//		System.out.println(AddString(times)  + "  PK  " + AddStringBuilder(times));
//		System.out.println("fuck");
//		String s1,s2,s3,s4;
//		char cs[];
//		s1 = "1b3";
//		s2 = "d5f";
//		s3 = s1 + s2;
//		//s4 = s2.toUpperCase();
//		s4 = new String("2013年8月21日");
//		s4 = s4.replace("日", "");
//		s4 = s4.replaceAll("[月年]", "-");
//		System.out.println(s1);
//		System.out.println(s2);
//		System.out.println(s3);
//		System.out.println(s4);
//		System.out.println("1".compareToIgnoreCase("C"));
//		System.out.println('1'-'C');
//		
	}
	
	public long AddString(int times)
	{
		long start = System.currentTimeMillis();
		for(int i =0;i<times;i++)
		{
		}
		//System.out.println(s.length());
		long end = System.currentTimeMillis();
		return end - start;
		
	}
	
	public long AddStringBuilder(int times)
	{
		long start = System.currentTimeMillis();
		StringBuilder buf = new StringBuilder();
		for(int i =0;i<times;i++)
		{
			buf.append('A');
		}
		//System.out.println(s.length());
		long end = System.currentTimeMillis();
		return end - start;
		
	}
	
	public long AddStringBuilder2(int times)
	{
		long start = System.currentTimeMillis();
		StringBuilder buf = new StringBuilder(times);
		for(int i =0;i<times;i++)
		{
			buf.append('A');
		}
		//System.out.println(s.length());
		long end = System.currentTimeMillis();
		return end - start;
		
	}
	
	public long AddStringBuffer(int times)
	{
		long start = System.currentTimeMillis();
		StringBuffer buf = new StringBuffer();
		for(int i =0;i<times;i++)
		{
			buf.append('A');
		}
		//System.out.println(s.length());
		long end = System.currentTimeMillis();
		return end - start;
		
	}
	
	public long AddChar(int times)
	{
		long start = System.currentTimeMillis();
		char str[] = new char[times];
		for(int i = 0 ;i<times;i++)
		{
			str[i] = 'A';
		}
		//System.out.println(str.length);
		long end = System.currentTimeMillis();
		return end - start;
		
	}
	
	
	public boolean equals(Object anObject) 
	{
		if (this == anObject) 
		{
		    return true;
		}
			return false;
	}
	
	 public int hashCode() 
	 {
		 return 0;
	 }
	
}
