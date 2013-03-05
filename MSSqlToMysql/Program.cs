﻿using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.ServiceProcess;

namespace QM.Client.UpdateDB
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FrmMain());
        //}

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SVUpdate() 
            };
            ServiceBase.Run(ServicesToRun);
        }
        
    }
}
