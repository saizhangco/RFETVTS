using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFTagSystemApp.Communication
{   
    /// <summary>
    /// 日志记录类
    /// </summary>
    class TraceLog
    {
        /// <summary>
        /// 默认的日志文件保存路径是"C:\serialOptLog\yyyy-MM-dd.txt"，
        /// 每一天的日志将保存在一个文件中。
        /// </summary>
        private string filepath = @"C:\serialOptLog\";

        public void trace(string func, string log)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string _log = "<" + time + "    " + func + "    " + log + ">\n";
            trace(_log);
        }

        public void trace(string log)
        {
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;

            string filename = "" + year + "-" + (month > 9 ? "" + month : "0" + month) + "-" + (day > 9 ? "" + day : "0" + day) + ".txt";

            FileStream fs = null;
            try
            {
                fs = new FileStream(filepath + filename, FileMode.Append, FileAccess.Write);

                byte[] bytes = Encoding.ASCII.GetBytes(log);
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception) { }
            if (fs != null)
            {
                fs.Close();
            }
        }

        // 默认构造函数 Constructor
        public TraceLog()
        {

        }

        public string Filepath
        {
            set
            {
                this.filepath = value;
            }
        }
    }
}
