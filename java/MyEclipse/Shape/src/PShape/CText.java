package PShape;

public class CText {
	public static void main(String[] args)
	{
		CPoint O = new CPoint(0,0);
		CPoint P = new CPoint(2,3);
		CPoint Q = new CPoint(-1,-1);
		System.out.println(O.Distance(P));
		
		CCircle c = new CCircle(P,1);
		System.out.println(c.Area());
		System.out.println(c.Perimeter());
		
		CRectangle s = new CRectangle(Q,-3,-3);
		s.getB().print();
		System.out.println(s.Area());
		System.out.println(s.Perimeter());
		System.out.println(s.getWidth());
		System.out.println(s.getHigh());
		
		System.out.println(c.getCenter().Distance(Q) );
		
		CCircle c2 = new CCircle(Q,1);
		System.out.println(c2.r);
		System.out.println(s.isSquare());
		boolean isCircleType = c instanceof CCircle;
		System.out.println(isCircleType);
		System.out.println(P.equals(new CPoint(2,3)));
		System.out.println(c);
		System.out.println(s);
	}
}
