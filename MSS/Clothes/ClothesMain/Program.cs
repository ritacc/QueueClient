using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSSClass;
using MSS;

namespace Clothes.SellingClothes
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			appconifg.m_DBConnectionPath = string.Format("{0}\\DBMSS.mdb", Application.StartupPath);

            Application.Run(new FrmLogin());
            if (Globals.isLogin)
            {
                Application.Run(new Main());
            }
            Application.Exit();


        }
    }
}