import java.io.*;

public class scan2{
	public static void main(String[] args) throws IOException
	{
		BufferedReader buf;
		buf = new BufferedReader(new InputStreamReader(System.in));
		System.out.print("Enter some words;");
		String str;
		str = buf.readLine();
		System.out.print(str);
	}
}
