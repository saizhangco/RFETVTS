using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFTagSystemApp
{
    class Session
    {
        private int tagid;
        private string shortAddr;
        private string takeResult;
        private string alerResult;
        private string pingResult;
        private bool locked;

        public string GetReceivedMessage(string command)
        {
            if(command == "TAKE")
            {
                return takeResult;
            }
            else if( command == "ALER" )
            {
                return alerResult;
            }
            else if( command == "PING" )
            {
                return pingResult;
            }
            else
            {
                return "";
            }
        }

        public void Clear(string command)
        {
            if (command == "TAKE")
            {
                takeResult = "";
            }
            else if (command == "ALER")
            {
                alerResult = "";
            }
            else if (command == "PING")
            {
                pingResult = "";
            }
        }

        public Session(int tagid)
        {
            this.tagid = tagid;
            shortAddr = "";
            takeResult = "";
            alerResult = "";
            pingResult = "";
            locked = false;
        }

        public string ShortAddr
        {
            get { return shortAddr; }
            set { shortAddr = value; }
        }

        public string TakeResult
        {
            get { return takeResult; }
            set { takeResult = value; }
        }

        public string AlerResult
        {
            get { return alerResult; }
            set { alerResult = value; }
        }

        public string PingResult
        {
            get { return pingResult; }
            set { pingResult = value; }
        }

        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

    }
}
