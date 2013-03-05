using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using ritacc.ServerAdmin;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;

namespace ServerInstall
{
    public partial class FrmDatabaseset : Form
    {
        public FrmDatabaseset()
        {
            InitializeComponent();
        }
        #region mssql 
        private void btnMSSqlTest_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(getMSSqlCon());
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                MessageBox.Show("连接成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private string getMSSqlCon()
        {
            string strMSSqlCon = string.Format("Data Source={0};uid={1};pwd={2};Initial Catalog={3};Timeout=300000000",
               txtBcmIp.Text, txtBcmUid.Text, txtBcmPwd.Text, txtBcmName.Text);
            return strMSSqlCon;
        }
        private string GetMySqlCon()
        {
            string strMySql = "DRIVER={MySQL ODBC 5.1 Driver};SERVER=" + txtMysqlIP.Text
                + ";DATABASE=" + txtMysqlDB.Text + ";UID=" + txtMysqlUserName.Text +
                ";PASSWORD=" + txtMySqlPwd.Text + ";OPTION=3;charset=UTF8;";
                    
            return strMySql;
        }
        private bool SaveMSSqlDBSet()
        {
            try
            {
                
                string strErrorMsg = "";
                if (string.IsNullOrEmpty(txtBcmIp.Text))
                {
                    strErrorMsg += "MMSql:“IP”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtBcmName.Text))
                {
                    strErrorMsg += "MMSql:“数据库名”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtBcmUid.Text))
                {
                    strErrorMsg += "MMSql:“用户名”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtBcmPwd.Text))
                {
                    strErrorMsg += "MMSql:“密码”不能为空。\r\n";
                }
                
                
                              
                if(string.IsNullOrEmpty(txtMysqlIP.Text))
                {
                    strErrorMsg += "Mysql:“IP”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtMysqlDB.Text))
                {
                    strErrorMsg += "Mysql:“数据库名”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtMysqlUserName.Text))
                {
                    strErrorMsg += "Mysql:“用户名”不能为空。\r\n";
                }
                if (string.IsNullOrEmpty(txtMysqlDB.Text))
                {
                    strErrorMsg += "Mysql:“密码”不能为空。\r\n";
                }
                if (!string.IsNullOrEmpty(strErrorMsg))
                {
                    MessageBox.Show(strErrorMsg);
                    return  false;
                }
                //初使化MySql
                
                string strMSSqlCon = getMSSqlCon();
                string strMySql = GetMySqlCon();

                string path = Common.GetStartPath(GlobalOR.ServerExeName + ".config");
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = path;

                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                //实例化mssql
                config.ConnectionStrings.ConnectionStrings["Queue"].ConnectionString = strMSSqlCon;
                config.ConnectionStrings.ConnectionStrings["MySql"].ConnectionString = strMySql;
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void InitDBSet()
        {
            try
            {
                //string path = Application.StartupPath + "\\web.config";
                string path = Common.GetStartPath(GlobalOR.ServerExeName + ".config");

               // string path = Common.GetStartPath(GlobalOR.ServerExeName + ".config");
                if (!File.Exists(path))
                {
                    MessageBox.Show(string.Format("配置文件：“{0}”不存在！", path));
                    return;
                }                
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = path;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                //实例化mssql
                string nodeMsSqlValue= config.ConnectionStrings.ConnectionStrings["Queue"].ConnectionString;
                //server=.;database=Queue;uid=sa;pwd=sa1111
                string[] arrBcmValue = nodeMsSqlValue.Split(';');
                txtBcmIp.Text = StrCommon.GetParamValue(ref nodeMsSqlValue, "server=", ";");
                txtBcmName.Text = StrCommon.GetParamValue(ref nodeMsSqlValue, "database=", ";");

                txtBcmUid.Text = StrCommon.GetParamValue(ref nodeMsSqlValue, "uid=", ";");
                txtBcmPwd.Text = StrCommon.GetParamValue(ref nodeMsSqlValue, "pwd=", "");
                

                //初使化MySql
                //DRIVER={MySQL ODBC 5.1 Driver};SERVER=localhost;DATABASE=queueclient;
                //UID=root;PASSWORD=ABCabc123;OPTION=3;charset=UTF8;
                string strMySql = config.ConnectionStrings.ConnectionStrings["MySql"].ConnectionString;
                txtMysqlIP.Text = StrCommon.GetParamValue(ref strMySql, "SERVER=", ";");
                txtMysqlDB.Text = StrCommon.GetParamValue(ref strMySql, "DATABASE=", ";");
                txtMysqlUserName.Text = StrCommon.GetParamValue(ref strMySql, "UID=", ";");
                txtMySqlPwd.Text = StrCommon.GetParamValue(ref strMySql, "PASSWORD=", ";");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private void btnMysqlTest_Click(object sender, EventArgs e)
        {

            OdbcConnection con=null;
            try
            {
                string mysql = GetMySqlCon();
                con = new OdbcConnection(GetMySqlCon());
                if (con.State == ConnectionState.Closed)
                    con.Open();
                MessageBox.Show("连接成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (!SaveMSSqlDBSet())
            {
                return;
            }

            FrimServiceStart frm = new FrimServiceStart();
            frm.Show();
            this.Hide();
        }

        private void FrmDatabaseset_Load(object sender, EventArgs e)
        {
            InitDBSet();
        }

       

       
    }
}
