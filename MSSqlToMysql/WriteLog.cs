using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Windows.Forms;

namespace QM.Client.UpdateDB
{
    public class WriteLog
    {

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="FileText"></param>
        #region Flie
        public static string _LogPath = string.Empty;
        public static string LogPath
        {
            get
            {
                return GetPath("Log");
            }
        }

        /// <summary>
        /// 写入异常信息\字符串
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <param name="FileText"></param>
        public static void writLog(string ErrorCode, string FileText)
        {
            try
            {
                string path = string.Format("{0}{1}log.txt", LogPath, DateTime.Now.ToString("yyyy-MM-dd"));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(string.Format("ErrorCode:{0} ;时间：{1},{2}", ErrorCode, System.DateTime.Now, FileText));
                sw.Flush();
                sw.Dispose();
                fs.Dispose();
            }
            catch
            {
            }
        }

       

        

        /// <summary>
        /// 获取启动目录下，指定文件夹的路径，并以\结束
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public static string GetPath(string FolderName)
        {
            string _LogPath = Application.StartupPath;

            if (!_LogPath.EndsWith("\\"))
            {
                _LogPath += "\\";
            }
            if (string.IsNullOrEmpty(FolderName))
                return _LogPath;
            _LogPath = string.Format("{0}{1}\\", _LogPath, FolderName);
            if (Directory.Exists(_LogPath))
            {
                return _LogPath;
            }
            else
            {
                Directory.CreateDirectory(_LogPath);
                return _LogPath;
            }
        }

        /// <summary>
        /// 写入异常信息，Exception
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <param name="ex"></param>
        public static void writLog(string ErrorCode, Exception ex)
        {
            try
            {
                //string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log.txt");
                string path = string.Format("{0}{1}log.txt", LogPath, DateTime.Now.ToString("yyyy-MM-dd"));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(string.Format("ErrorCode:{0} ;时间：{1},{2}", ErrorCode, System.DateTime.Now, ex.Message));// ex.StackTrace));
                sw.Flush();
                sw.Dispose();
                fs.Dispose();
            }
            catch
            {
            }
        }

        #endregion


        /// <summary>
        /// 写入异常信息\字符串
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <param name="FileText"></param>
        public static void writeMsgLog(string ErrorCode, string msg, bool isAddLine = false)
        {
            try
            {
                string path = string.Format("{0}log{1}Msg.txt", LogPath, DateTime.Now.ToString("yyyy-MM-dd"));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                
                sw.BaseStream.Seek(0, SeekOrigin.End);
                if (isAddLine)
                {
                    sw.WriteLine();
                    sw.WriteLine();
                }
                sw.WriteLine(string.Format("ErrorCode:{0} ;时间：{1},{2}", ErrorCode, System.DateTime.Now, msg));
                sw.Flush();
                sw.Dispose();
                fs.Dispose();
            }
            catch
            {
            }
        }


    }
}
