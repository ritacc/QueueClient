using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace OnlineSwitch
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        string CurrentDB = string.Empty;
        string configPath = string.Empty;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            if (!path.EndsWith("\\"))
                path += "\\";
            path+="web.config";
            configPath = path;
            if (!File.Exists(configPath))
            {
                MessageBox.Show("web.config不件不存在！","出错啦！");
                this.Close();
                return;
            }
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(configPath);
            XmlNode xn = xdoc.SelectSingleNode("configuration/dataConfiguration");
            if (xn != null)
            {
                CurrentDB = xn.Attributes["defaultDatabase"].Value;
            }

            if (CurrentDB == "MySql")//联机
            {
                btnSwitch.Text = "切换到 脱机 状态";
                lblStatus.Text = "当前状态为："+"联机";
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                btnSwitch.Text = "切换到 联机 状态";
                lblStatus.Text = "当前状态为：" + "脱机";
                lblStatus.ForeColor = Color.Red;
            }            
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            string showMsg = string.Format("确定要将数据库{0}吗？", btnSwitch.Text);
            if (MessageBox.Show(showMsg, "询问?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string value = "";
                if (CurrentDB == "MySql")
                {
                    value = "MySqlUnline";
                }
                else
                {
                    value = "MySql";
                }
                if (ChageDB(value))
                {
                    this.Close();
                }                
            }
        }

        public bool ChageDB(string Value)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(configPath);
            XmlNode xn = xdoc.SelectSingleNode("configuration/dataConfiguration");
            xn.Attributes["defaultDatabase"].Value = Value;
            xdoc.Save(configPath);

           string mainAppExe = Application.StartupPath + "\\stopW3p.vbs";
            if (File.Exists(mainAppExe))
                Process.Start(mainAppExe);
            //重启服务
            return true;
        }
    }
}
