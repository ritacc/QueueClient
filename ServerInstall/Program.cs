using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Configuration;

namespace ServerInstall
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            OpType mop = OpType.Install;
            if (args.Length > 0)
            {
                if (args[0] == "UnInstall")
                {
                    mop = OpType.UnInstall;
                }
            }
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            FrmMain frm = new FrmMain();
            frm.MOpType = mop;

            //Application.Run(frm);
            Application.Run(new FrmDatabaseset());
        }
    }
}
