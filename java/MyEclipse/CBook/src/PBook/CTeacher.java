package PBook;

public class CTeacher extends CUser{
	private String profession = "teacher";
	
	public CTeacher()
	{
		super(54);
	}
	
	public String GetProf()
	{
		return this.profession;
	}

}
