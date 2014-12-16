package PBook;

public class CUser {
	int id=10;
	String name;
	int age;
	char sex;
	String bplace;
	String department;
	CBook[] borrow;
	
	public CUser(int n)
	{
		this.id = n;
		return;
	}
	
	public CUser()
	{
		return;
	}
}
