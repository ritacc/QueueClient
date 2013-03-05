using System;
using System.Collections.Generic;
using System.Text;

namespace ServerInstall
{
   public class GlobalOR
    {
        /// <summary>
        /// 服务程序名称，启动时初使化
        /// </summary>
       public static string ServerExeName = "UpdateServer.exe";

       /// <summary>
       /// 服务名称
       /// 初使化时，获取服务名称
       /// </summary>
       public static string ServerName = "";
    }
}
