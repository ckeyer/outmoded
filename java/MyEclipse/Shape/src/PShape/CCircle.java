package PShape;

// ‘≤¿‡

public class CCircle extends  CShape{
	public CPoint center;
	double r=0;
	
	public CCircle(CPoint o,double r)
	{
		this.setCenter(o);
		this.setR(r);
	}
	
	public CCircle(double x, double y, double r)
	{
		this.center.setX(x);
		this.center.setY(y);
		this.setR(r);
	}
	
	public CCircle()
	{
		return;
	}
	
	public double Area()
	{
		return Math.PI * Math.pow(this.r,2);
	}
	
	public double Perimeter()
	{
		return Math.PI * 2 * this.r;
	}
	
	public CPoint getCenter()
	{
		return this.center;
	}
	
	public double getR()
	{
		return this.r;
	}
	
	public void setCenter(CPoint o)
	{
		this.center = o;
	}

	public void setR(double r)
	{
		this.r = r;
	}
	
	public String toString()
	{
		return "Circle[" + this.center.toString() + "," + this.r + "]";
	}
}
