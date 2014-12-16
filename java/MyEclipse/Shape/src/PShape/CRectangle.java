package PShape;

// æÿ–Œ¿‡

public class CRectangle extends CShape{
	CPoint a;
	CPoint b;
	
	public CRectangle(CPoint a , CPoint b)
	{
		this.a = a;
		this.b = b;
	}
	
	public CRectangle(double ax,double ay,double bx,double by)
	{
		this.a.setXY(ax, ay);
		this.b.setXY(bx, by);
	}
	
	public CRectangle(CPoint a,double width,double high)
	{
		this.a = a;
		this.b = new CPoint(a.getX() + width,a.getY() + high);
	}
	
	public CRectangle()
	{
		return;
	}
	
	public double Area()
	{
		return Math.abs((this.a.getX() - this.b.getX())*(this.a.getY() - this.b.getY()));
	}
	
	public double Perimeter()
	{
		return  2 * (Math.abs(this.a.getX() - this.b.getX())+Math.abs(this.a.getY()-this.b.getY()));
	}
	
	public double getWidth()
	{
		return Math.abs( a.getX() - b.getX());
	}
	
	public double getHigh()
	{
		return Math.abs( a.getX() - b.getY());
	}

	public CPoint getA()
	{
		return this.a;
	}
	
	public CPoint getB()
	{
		return this.b;
	}
	
	public void setA(CPoint a)
	{
		this.a=a;
	}
	
	public void setB(CPoint b)
	{
		this.b=b;
	}
	
	public boolean isSquare()
	{
		if(Math.abs(this.a.getX() - this.b.getX()) == Math.abs(this.b.getY() - this.a.getY()))
		{
			return true;
		}
		else 
		{
			return false;
		}
	}
	
	public boolean isGolden()
	{
		
		return false;
	}
	
	public String toString()
	{
		return "Rectangle[" + this.a + "," + this.b + "]";
	}
}
