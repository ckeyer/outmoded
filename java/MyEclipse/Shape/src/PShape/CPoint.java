package PShape;

// µ„¿‡

public class CPoint {
	private double x;
	private double y;
	
	public CPoint(){}
	
	public CPoint(double x,double y )
	{
		this.x = x;
		this.y = y;
		return;
	}
	
	public double Distance(CPoint other)
	{
		return Math.sqrt(Math.pow(this.x - other.x, 2) + Math.pow(this.y - other.y, 2));
	}
	
	public double getX()
	{
		return x;
	}
	
	public double getY()
	{
		return y;
	}
	
	public void setX(double x)
	{
		this.x = x;
	}
	
	public void setY(double y)
	{
		this.y = y;
	}

	public void setXY(double x,double y)
	{
		this.x=x ;
		this.y =y;
	}
	
	public void print()
	{
		System.out.println("(" + this.x + "," +this.y +")");
	}
	
	public boolean equals(Object obj) 
	{
		if(null == obj) 
		{
			return false;
		}
		if(obj == this)
		{
			return true;
		}
		if(obj instanceof CPoint)
		{
			CPoint other = (CPoint) obj;
			return (this.x == other.x && this.y == other.y);
		}
		return false;
    }
	
	public int hashCode()
	{
		return (int ) (this.x *10000 + this.y );
	}
	
	public String toString()
	{
		return "Point(" + this.getX() + "," +this.getY() + ")" ;
	}
}
