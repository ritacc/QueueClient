using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace QM.Web
{
    public class CommonHead
    {
        public static bool HeadString()
        {
            return false; 
        }

        public static string GetStr(string sObj, int intLen)
        {
            if (sObj.Length > intLen)
            {
                return sObj.Substring(0, intLen) + "…";
            }
            return sObj; 
        }

        public static int GetMonthDay(int Year, int Month)
        {
            if (Month == 2)
            {
                if (Year % 4 == 0)
                    return 29;
                else
                    return 28;
            }
            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                return 31;
            return 30;
        }

        public static bool isImg(string FileName)
        {
            string[] extendFileName = { ".psd", ".jpg", ".gif", ".bmp", ".BMP", ".PSD", ".JPG", ".GIF" };

            string[] arr = FileName.Split('.');
            if (arr.Length == 0)
                return false;
            string cjm = "." + arr[arr.Length - 1];
            bool isimg = false;
            if (arr.Length == 2)
                for (int j = 0; j < extendFileName.Length && !isimg; j++)
                {
                    if (cjm == extendFileName[j])
                        isimg = true;
                }
            return isimg;
        }

        /// <summary>
        /// 获取文件长，最大单位MB
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static string GetFileLengStr(int f_size)
        {
            if (f_size == 0)
            {
                return "0KB";
            }
            float fileSize = float.Parse(f_size.ToString());
            if (fileSize <= 1024)
                return "1KB";
            float f = fileSize / 1024;
            if (f <= 1)
                return "1KB";

            if (f <= 100)
            {
                int f_len = 4;
                if (f.ToString().Length < 4)
                {
                    f_len = f.ToString().Length;
                }
                return f.ToString().Substring(0, f_len) + "KB";
            }
            f = f / 1024;
            string temp = f.ToString();
            int dindex = temp.IndexOf('.');
            if (dindex != -1)
            {
                int dAfertLeng = temp.Substring(0, dindex).Length;
                int i_xiaosLeng = temp.Length - dindex;
                if (i_xiaosLeng < 2)
                {
                    i_xiaosLeng = 1;
                }
                else
                {
                    i_xiaosLeng = 2;
                }
                string xiaosStr = temp.Substring(dindex + 1, i_xiaosLeng);
                return temp.Substring(0, dAfertLeng) + "." + xiaosStr + "MB";
            }
            return temp + "MB";
        }

        public static void SaveCartToImage(Chart chart1,string FilePath)
        {


            chart1.SaveImage(FilePath, ChartImageFormat.Png);
            //Image oldImg = new Bitmap(imgStream);
            //Image newImg = new Bitmap(oldImg.Width, oldImg.Height - 189);
            //Graphics g = Graphics.FromImage(newImg);
            //g.Clear(Color.WhiteSmoke);
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.DrawImage(oldImg, new Point(0, 0));
            //g.Dispose();
        }

    }
}