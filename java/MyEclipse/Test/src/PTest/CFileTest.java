package PTest;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FilenameFilter;
import java.io.IOException;
import java.io.InputStream;
import java.io.RandomAccessFile;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class CFileTest implements ITest {

	@Override
	public void test() {
		System.out.println("test about File");

		File file = new File("H:\\WCJ\\test\\fs.txt");
		File file2;
		File dir = new File("H:/WCJ/WebSite");
		File dir2 = new File("NEW.txt");
		String[] list;

//		System.out.println(file.getAbsoluteFile());
		DateFormat dfm = new SimpleDateFormat("yyyy-MM-dd E kk:mm:ss");
//		System.out.println(dfm.format(file.lastModified()));
		// System.out.println(file.isFile());
		// System.out.println(file.isDirectory());
		// System.out.println(file.length());
		if (!dir.exists()) {
			dir.mkdir();
		}
		// System.out.println(dir.exists());
		// dir.delete();
		// System.out.println(dir.exists());
		// dir.renameTo(dir2);

		// list = dir.list();
		// if(dir.isDirectory())
		// {
		// //System.out.println(ArrayList);
		// for(int i = 0;i<list.length ; i++)
		// {
		// String s = list[i];
		// System.out.println(s);
		// }
		// }
		// file2 = new File() ;
		// this.myLs(dir);
		file = new File("H:\\WCJ\\test\\fs.txt");
//		try {
//			System.out.println(this.readToByte(file));
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
		try {
			InputStream in = new FileInputStream(file);
			byte[] bfile = new byte[30];
			for(int b=in.read();b>0;b=in.read())
			{
				System.out.print((char)b);
			}
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public byte[] readToByte(File file) throws IOException {

		byte[] bfile;
		RandomAccessFile raf = new RandomAccessFile(file, "rw");
		bfile = new byte[(int) raf.length()];
		int count = raf.read(bfile);
		 raf.close();
		return bfile;
	}

	public void myLs(File file) {
		String str1 = file.getAbsoluteFile().toString();
		StringBuilder sceng = new StringBuilder();
		int ceng = 1;
		String sdir;
		sdir = str1;
		File dir = new File(sdir);
		String[] list = dir.list();
		for (int i = 0; i < ceng; i++) {
			sceng.append("-");
		}
		for (int i = 0; i < list.length; i++) {
			String temp = list[i];
			System.out.println(sceng.toString() + temp);
			String temp2 = dir.getAbsolutePath() + "/" + temp;
			File ftemp = new File(temp2);
			if (ftemp.isDirectory()) {
				this.myLs(ftemp, ++ceng);
			}
		}
	}

	public void myLs(File file, int ceng) {
		String str1 = file.getAbsoluteFile().toString();
		StringBuilder sceng = new StringBuilder();
		String sdir;
		sdir = str1;
		File dir = new File(sdir);
		String[] list = dir.list();
		for (int i = 0; i < ceng; i++) {
			sceng.append("-");
		}
		for (int i = 0; i < list.length; i++) {
			String temp = list[i];
			System.out.println(sceng.toString() + temp);
			String temp2 = dir.getAbsolutePath() + "/" + temp;
			File ftemp = new File(temp2);
			if (ftemp.isDirectory()) {
				this.myLs(ftemp, ++ceng);
			}
		}
	}

	static class Filter implements FilenameFilter {
		public Filter() {
			// TODO Auto-generated constructor stub
		}

		@Override
		public boolean accept(File dir, String name) {
			// TODO Auto-generated method stub
			return false;
		}
	}
}
