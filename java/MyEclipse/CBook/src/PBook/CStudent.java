package PBook;

public class CStudent extends CUser {
	private String profession = "student";
	
	public CStudent(){
		super(32);
	}
	
	public String GetProf()
	{
		return this.profession;
	}

}
