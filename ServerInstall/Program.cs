using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Configuration;
using System.IO;
using ritacc.ServerAdmin;

namespace ServerInstall
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        //static void Main(String[] args)
        //{
        //    OpType mop = OpType.Install;
        //    //if (args.Length > 0)
        //    //{
        //    //    if (args[0] == "UnInstall")
        //    //    {
        //    //        mop = OpType.UnInstall;
        //    //    }
        //    //}

        //    //mop = OpType.UnInstall;

        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    FrmMain frm = new FrmMain();
        //    frm.MOpType = mop;

        //    Application.Run(frm);
        //    //Application.Run(new FrmDatabaseset());
        //}

        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmDataParaSet frm = new frmDataParaSet();
            Application.Run(frm);
        }


        //[STAThread]
        //static void Main(String[] args)
        //{
        //   //启动
        //    if (!File.Exists(Common.GetStartPath("ServerConfig.ini")))
        //    {
        //        return;
        //    }
        //    IniFile _Ini;
        //    string iniPath = Common.GetStartPath("ServerConfig.ini");
        //    _Ini = new IniFile(iniPath);
        //    GlobalOR.ServerExeName = _Ini.ReadString("Path", "InstallProgramName", "ReceiveTrapManagem.exe");

        //    if (!ServerControl.GetServerNameByFile(GlobalOR.ServerExeName, out GlobalOR.ServerName))
        //    {
        //        return;
        //    }
        //    ServerControl.StartService(GlobalOR.ServerName);
        //}
    }
}
