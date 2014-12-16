package PTest;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class CTimeTest implements ITest{
	public void test()
	{
		long now ;
		int year;
		now = System.currentTimeMillis();
		year =(int) (now/1000/60/60/24/365)+1970;
		Date d = new Date(now);
		Calendar cal = new GregorianCalendar();
		Calendar calex = new GregorianCalendar();
		cal.setTime(d);
		DateFormat fmt = new SimpleDateFormat("z yyyy-MM-dd E ");
		String str = fmt.format(d);
		System.out.println(str);
		
		System.out.println(year);
//		System.out.println(d.getYear()+1900);
//		System.out.println(d.getMonth()+1);
//		System.out.println(d.getDay());
		calex = spDay(cal, 6);
		str = fmt.format(calex.getTime());
		System.out.println(str);
	}
	
	// 生产日期和保质期，要求过期前两周的周五开始进行促销
	public Calendar spDay(Calendar creatTime,int expMonths)
	{
//		Calendar calsp = new GregorianCalendar();
//		Date d = new Date();
//		d  = creatTime.getTime();
		creatTime.set(Calendar.MONTH,creatTime.get(Calendar.MONTH)+expMonths);
		creatTime.set(Calendar.WEEK_OF_YEAR,creatTime.get(Calendar.WEEK_OF_YEAR)-2);
		creatTime.set(Calendar.DAY_OF_WEEK,Calendar.FRIDAY);
		return creatTime; 
	}

}
