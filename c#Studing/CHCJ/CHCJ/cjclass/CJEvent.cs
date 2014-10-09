using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHCJ
{
    public delegate void DelegateConnectHandle(object sender, CJReceiveOverEvent e);
    public delegate void DelegateLogHandle(object sender, CJLogEvent e);
    public delegate void DelegateActiveFriendHandle(object sender, CJActiveFriendEvent e);

    public class CJReceiveOverEvent : EventArgs
    {
        public CJReceiveOverEvent()
        { }

        private  CJMsg msg;
        private CHCJ.SendState sendstate;
        public CJMsg Msg
        {
            get { return msg; }
            set { this.msg = value; }
        }
        public CHCJ.SendState sendState
        {
            get { return sendstate; }
            set { this.sendstate = value; }
        }
        public string Remark;
        private CJLog.LogLevel level;
        public CJLog.LogLevel Level
        {
            get { return level; }
            set { this.level = value; }
        }
    }

    public class CJLogEvent : EventArgs
    {
        public CJLogEvent()
        { }

        private string _logstr;
        public string logStr
        {
            get { return _logstr; }
            set { this._logstr = value; }
        }
    }

    public class CJActiveFriendEvent : EventArgs
    {
        public CJActiveFriendEvent()
        { ;}
        public  string Id;
        public string Type;
    }
}
