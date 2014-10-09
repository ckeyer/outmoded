using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHCJ
{
    class LocalUser // 保存本地用户相关信息
	{
        public string userID, userName, password;
        public bool is_auto_login = false, is_rem_passwd = false;
        public string last_login_time_string;
        public DateTime last_login_time;

        public static int CompareByDate(LocalUser x, LocalUser y)
        {
            TimeSpan t = x.last_login_time.Subtract(y.last_login_time);
            if (t.Ticks>0)
            {
                return -1;
            }
            return 1;
        }  
	}
}
