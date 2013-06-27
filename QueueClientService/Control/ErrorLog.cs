using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace QM.Client.WebService.Control
{
    public class ErrorLog
    {

       

        protected static string GetFilePath()
        {            
            string strTime = DateTime.Now.ToString("yyyyMMdd");
            return string.Format("{0}log{1}.txt", Common.GetPath(), strTime);
        }

        public static void WriteLog(string ErrorCode, string msg)
        {
            string path = GetFilePath();

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(string.Format("ErrorCode:{0} ;时间：{1},{2}", ErrorCode, System.DateTime.Now, msg));
            sw.Flush();
            sw.Dispose();
            fs.Dispose();
        }
    }
}