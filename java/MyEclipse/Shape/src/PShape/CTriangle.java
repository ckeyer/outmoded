package PShape;

// 三角形类

public class CTriangle extends CShape 
{
	CPoint A,B,C;	// 三顶点位置
	double a,b,c;	// 三边边长
	
	public CTriangle(){}
	
	public CTriangle(CPoint a ,CPoint b, CPoint c)
	{
		this.A = a;
		this.B = b;
		this.C = c;
	}
	
	public void initialization()
	{
		this.a = this.A.Distance(this.B);
		this.b = this.B.Distance(this.C);
		this.c = this.C.Distance(this.A);
		
	}

	public double Area() 
	{
		return a+b+c;
	}

	public double Perimeter() 
	{
		return a+b+c;
	}

}
