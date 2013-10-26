using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using QSoft.Core.Util;
 

namespace QSoft.Core.Uitl.Logger
{
    public class ErrorLog
    {
        protected static string GetFilePath()
        {
            string strTime = DateTime.Now.ToString("yyyyMMdd");
            return string.Format("{0}log\\log{1}.txt", Common.GetStartpath(), strTime);
        }
        public static object objLog = new object();
        public static void WriteLog(string ErrorCode, string msg)
        {
            try
            {
                lock (objLog)
                {
                    string path = GetFilePath();
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(string.Format("时间：{0} ,ErrorCode:{1},{2}", System.DateTime.Now, ErrorCode, msg));
                    sw.Flush();

                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch
            {

            }
        }

        protected static string GetTestFilePath()
        {
            string strTime = DateTime.Now.ToString("yyyyMMdd");
            return string.Format("{0}log\\testlog{1}.txt", Common.GetStartpath(), strTime);
        }
        public static object TestLog = new object();
        public static void WriteTestLog(string ErrorCode, string msg)
        {
            try
            {
                lock (TestLog)
                {
                    string path = GetTestFilePath();
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(string.Format("时间：{0},ErrorCode:{1} ;{2}", System.DateTime.Now, ErrorCode, msg));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();

                    fs.Close();
                    fs.Dispose();
                }
            }
            catch
            {

            }
        }
    }
}
