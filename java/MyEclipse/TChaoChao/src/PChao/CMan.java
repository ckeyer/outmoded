package PChao;

public class CMan
{
	private boolean istrue = true;
	public  int id ;
	public CMan[] someone;
	
	public CMan(){}
	
	public CMan(int id)
	{
		this.id = id ;
	}
	
	public CMan(int id ,CMan[] someones)
	{
		this.id = id;
		this.someone = someones;
		for (int i=0; i< someones.length; i++)
		{
			someones[i].makefalse();
			System.out.println(id+"is false");
		}
	}
	
	public void  makefalse()
	{
		this.istrue = false ;
	}
	
	public void  sayotherfalse(CMan someone)
	{
		someone.istrue = false ;
	}
}
