using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using ritacc.ServerAdmin;
using System.Xml;
using System.Data.SqlClient;

namespace ServerInstall
{
  public  enum OpType
    {
        Install,UnInstall,Admin
    }

    public partial class FrmMain : Form
    {
        

        /// <summary>
        /// ini文件读取操作
        /// </summary>
        IniFile _Ini;
        
        

        /// <summary>
        /// 线程中显示信息
        /// </summary>
        /// <param name="str"></param>
        public delegate void MyInvoke(string str);

        private OpType _OpType;

        public OpType MOpType
        {
            get { return _OpType; }
            set { _OpType = value; }
        }

      


        public FrmMain()
        {
            InitializeComponent();

            if (!File.Exists(Common.GetStartPath("ServerConfig.ini")))
            {
                AddShowMsg("配置文件：“ServerConfig.ini”不存在！");
                return;
            }

            string iniPath = Common.GetStartPath("ServerConfig.ini");
            _Ini = new IniFile(iniPath);
            GlobalOR.ServerExeName = _Ini.ReadString("Path", "InstallProgramName", "ReceiveTrapManagem.exe");
        }
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //检查服务文件是否存在
            if (!File.Exists(Common.GetStartPath(GlobalOR.ServerExeName)))
            {
                AddShowMsg(string.Format("服务文件：“{0}”不存在！", GlobalOR.ServerExeName));
                return;
            }

            string path = Common.GetStartPath(GlobalOR.ServerExeName + ".config");
            if (!File.Exists(path))
            {
                AddShowMsg(string.Format("配置文件：“{0}”不存在！", GlobalOR.ServerExeName + ".config"));
                return;
            }

            if (this.MOpType == OpType.Install)
            {
                gpServer.Text = string.Format("安装服务信息：");

                Thread th = new Thread(ServerInsatll);
                th.Start();
            }
            else if (this.MOpType == OpType.UnInstall)
            {
                gpServer.Text = string.Format("卸载服务信息：");

                btnnext.Text = "确定";
                this.Text = "卸载服务";
                Thread th = new Thread(ServerUnInsatll);
                th.Start();
            }
        }

        /// <summary>
        /// 起用下一步按钮
        /// </summary>
        /// <param name="State"></param>
        private void EnableNext(string State)
        {
            if (btnnext.InvokeRequired)
            {
                MyInvoke _myInvoke = new MyInvoke(EnableNext);
                this.Invoke(_myInvoke, new object[] { State });
            }
            else
            {
                btnnext.Enabled = true;
            }
        }

        #region 服务处理
        /// <summary>
        /// 处理服务安装
        /// </summary>
        public void ServerInsatll()
        {
            //检查服务文件是否存在
            if (!File.Exists(Common.GetStartPath(GlobalOR.ServerExeName)))
            {
                AddShowMsg(string.Format("服务文件：“{0}”不存在！", GlobalOR.ServerExeName));
                return;
            }
            //获取服务名称
            if (!ServerControl.GetServerNameByFile(GlobalOR.ServerExeName, out GlobalOR.ServerName))
            {
                AddShowMsg(GlobalOR.ServerName);
                return;
            }
            else
            {
                AddShowMsg(string.Format("服务名称：“{0}”！", GlobalOR.ServerName));
            }

            string ServerStata = ServerControl.GetServerStatus(GlobalOR.ServerName);
            AddShowMsg(string.Format("服务：{0},当前状态：{1}", GlobalOR.ServerName, ServerStata));
            if (ServerStata.IndexOf("不存在") > 0)
            {
                AddShowMsg("开始安装服务。。。");
                AddShowMsg(ServerControl.InstallmyService(null, GlobalOR.ServerExeName));
                EnableNext("0");
            }
            else
            {
                AddShowMsg("开始卸载服务。。。");
                AddShowMsg(ServerControl.UnInstallService(GlobalOR.ServerExeName));
                AddShowMsg("开始安装服务。。。");
                AddShowMsg(ServerControl.InstallmyService(null, GlobalOR.ServerExeName));
                EnableNext("0");
            }
        }
        public void ServerUnInsatll()
        {
            //检查服务文件是否存在
            if (!File.Exists(Common.GetStartPath(GlobalOR.ServerExeName)))
            {
                AddShowMsg(string.Format("服务文件：“{0}”不存在！", GlobalOR.ServerExeName));
                return;
            }
            //获取服务名称
            if (!ServerControl.GetServerNameByFile(GlobalOR.ServerExeName, out GlobalOR.ServerName))
            {
                AddShowMsg(GlobalOR.ServerName);
                return;
            }
            else
            {
                AddShowMsg(string.Format("服务名称：“{0}”！", GlobalOR.ServerName));
            }

            string ServerStata = ServerControl.GetServerStatus(GlobalOR.ServerName);
            AddShowMsg(string.Format("服务：{0},当前状态：{1}", GlobalOR.ServerName, ServerStata));
            if (ServerStata.IndexOf("不存在") > 0)
            {
                EnableNext("0");
            }
            else
            {
                AddShowMsg("开始卸载服务。。。");
                AddShowMsg(ServerControl.UnInstallService(GlobalOR.ServerExeName));
                EnableNext("0");
            }
        }

        private void AddShowMsg(string msg)
        {
            if (lbItems.InvokeRequired)
            {
                MyInvoke _myInvoke = new MyInvoke(AddShowMsg);
                this.Invoke(_myInvoke, new object[] { msg });
            }
            else
            {
                lbItems.Items.Add(msg);
            }

        }

        private void HeadServerStatus()
        {
            //lblServerMsg.Text = string.Format("服务名称：{0},服务状态：{1}", ServerName, ServerControl.GetServerStatus(ServerName));
        }
        #endregion

        

        /// <summary>
        /// 下一步事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnnext_Click(object sender, EventArgs e)
        {
            if (this.MOpType == OpType.UnInstall)
            {
                Application.Exit();
            }
            else
            {
                FrmDatabaseset frm = new FrmDatabaseset();
                frm.Show();
                this.Hide();
            }
        }
    }
}
