package PTest;
import java.awt.BorderLayout;
import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JFrame;

public class CTest implements ITest {

	public CTest() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void test() {
		// TODO Auto-generated method stub
	
	/*
	 * 容器顶级容器 JFrame、JDialog、JApplet中间容器 JPanel
	 */
	/*
	 * 布局管理器 流式布局 FlowLayout 自上向下，自左向右 JPanel默认布局 边界布局 BorderLayout 东西南北中
	 * JFrame默认布局 网格布局 GridLayout 等分 卡片布局 网格包布局
	 */
	/*
	 * 组件 JButton
	 */
		// 生成界面(容器，container)
		JFrame mainFrame = new JFrame();
		// 设置界面布局(布局管理器，layoutManager)
		// mainFrame.setLayout(new FlowLayout());
		mainFrame.setLayout(new GridLayout(3, 2));
		// 生成按钮(组件，component)
		JButton b1 = new JButton();
		// 设置按钮文字
		b1.setText("东");
		// 生成按钮(组件，component)
		JButton b2 = new JButton();
		// 设置按钮文字
		b2.setText("西");
		JButton b3 = new JButton();
		// 设置按钮文字
		b3.setText("南");
		// 生成按钮(组件，component)
		JButton b4 = new JButton();
		// 设置按钮文字
		b4.setText("北");
		// 生成按钮(组件，component)
		JButton b5 = new JButton();
		// 设置按钮文字
		b5.setText("中");
		// 在界面中添加按钮
		mainFrame.add(b1, BorderLayout.EAST);
		mainFrame.add(b2, BorderLayout.WEST);
		mainFrame.add(b3, BorderLayout.SOUTH);
		mainFrame.add(b4, BorderLayout.NORTH);
		mainFrame.add(b5, BorderLayout.CENTER);
		// 设置大小
		mainFrame.setSize(400, 400);
		// 设置位置
		mainFrame.setLocation(312, 184);
		// 设置默认关闭方式exit dispose hide donothing
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		// 设置可显
		mainFrame.setVisible(true);
		b1.doClick();
	}

}
