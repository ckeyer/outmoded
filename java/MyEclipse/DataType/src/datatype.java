//数据类型的实验

public class datatype {
	public static void main(String[] args){
		int a = 1024*1024*1024*2-1; //java int 可以表示的最大的数 2G-1.
		System.out.println(a);
		//char 
		char ca = '中';	//  中
		char cb = '\u6587';
		System.out.println((char)(int)ca);
		System.out.println(0x80000001);
		System.out.println(Integer.toHexString(0x80000001));
		itox (22);
	}
	
	public static void itox(int i){
		if(i<=0x7fffffff && i>=0){
			int x[] = new int[8];
			int j=0;
			int leng=0;
			int cx[] = new int[8];
			while(i/16 > 0){
				x[j] = i%16;
				cx[j] = fiftof(x[j]);
				j++;
				i=i/16;
			}
			x[j]=i;
			cx[j] = fiftof(x[j]);
			for(int k=7;k>=0;k--){
				if(0 == cx[k] || '0' == cx[k])
					continue;
				else
				{
					leng = k;
					break;
				}
			}
			System.out.print("0x");
			for(int k=leng;k>=0;k--){
				if(0 == cx[k])
					System.out.print((char) 48);
				else
					System.out.print((char) cx[k]);
			}
		}
		else{
			System.out.print(" 输入的数据超过上限");
		}
		System.out.println();
	}
	
	public static int fiftof(int a){
		char x='0';
		if(a>=0 && a<=9){
			return  a+48;
		}
		else {
			switch(a){
				case 10: x='A';break;
				case 11: x='B';break;
				case 12: x='C';break;
				case 13: x='D';break;
				case 14: x='E';break;
				case 15: x='F';break;
				default: break;
			}
			return (int) x;
		}
	}
	
}
