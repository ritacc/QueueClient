using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ritacc.ServerAdmin;

namespace ServerInstall
{
    public partial class FrimServiceStart : Form
    {
        public FrimServiceStart()
        {
            InitializeComponent(); this.Icon = Resource.set;
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrimServiceStart_Load(object sender, EventArgs e)
        {
            if (ServerControl.StartService(GlobalOR.ServerName))
            {
                lblStartServer.Text = "服务启动成功。。。";
                //btnnext.Text = "完成";
            }
        }
    }
}
