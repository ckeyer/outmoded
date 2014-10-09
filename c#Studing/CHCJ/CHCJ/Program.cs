using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace CHCJ
{
    public static class Program
    {
        delegate void CB_V_O(object o);
        private static void start_Main(object o)
        {
            Application.Run(new MainForm((CJUser)o));
        }

        public static Thread t_mainForm = new Thread(new ParameterizedThreadStart(start_Main));
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CJConfig.init();
            //Application.Run(new LoginForm());
            //Application.Run(new TestForm1());
            Application.Run(new MainForm());
        }
    }
}
