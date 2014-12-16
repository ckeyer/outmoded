package PTest;

public class CExceptionTest implements ITest{
	StringBuilder sbu = new StringBuilder("Download you with my life!");
	
	@Override
	public void test() {
		System.out.println(sbu);
		try{
		System.out.println(index("fu"));
		}
		catch (NoWordsException e) {
			System.out.println(e.getMessage());
		}
	}
	
	public String index(String s) throws NoWordsException
	{
			if (0 < sbu.indexOf(s)) 
			{
				return "ÓÐ£¡£¡£¡" + sbu.indexOf(s);
			}
			throw new NoWordsException("Ä¾ÓÐÁË");
	}

}


//public class NoWordsException extends Exception{
//	public NoWordsException(String s) {
//		super(s);
//	}
//}
