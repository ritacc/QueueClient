using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QM.Client.Entity;
using QM.Client.DA.MySql;

namespace QM.Client.DeviceAdmin
{
    public partial class frmDeviceEdit : Form
    {
        public frmDeviceEdit()
        {
            InitializeComponent();
        }

        private void frmTPEdit_Load(object sender, EventArgs e)
        {
            if (opType != "add")
            {
                LoadData();
            }
            txtTypeName.Text = DeviceType.GetTypeName(Devicetypeid);
        }

        public string DeviceID{get;set;}
        public int Devicetypeid { get; set; }

        public bool IsOK { get; set; }

        public string opType { get; set; }

        DeviceDAMySql mDA = new DeviceDAMySql();
        private void LoadData()
        {
            try
            {
               DeviceOR m_devi = mDA.selectARowDate(DeviceID);

                txtWindowno.Text = m_devi.Windowno;//
                txtWindowtype.Text = m_devi.Windowtype;//
                txtDevicemodel.Text = m_devi.Devicemodel;//
                txtHostaddr.Text = m_devi.Hostaddr;//
                txtAddress.Text = m_devi.Address;//
            }
            catch (Exception e)
            {
                ShowMsg(e.Message);
            }
        }


        private DeviceOR SetValue()
        {
            DeviceOR m_devi =new DeviceOR();
            if (opType == "add")
                m_devi.Id = Guid.NewGuid().ToString();
            else
                m_devi.Id = DeviceID;
            
            m_devi.Devicetypeid = Devicetypeid;//
            m_devi.Windowno = txtWindowno.Text;//
            m_devi.Windowtype = txtWindowtype.Text;//
            m_devi.Devicemodel = txtDevicemodel.Text;//
            m_devi.Hostaddr = txtHostaddr.Text;//
            m_devi.Address = txtAddress.Text;//

            return m_devi;
        }

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWindowno.Text == "")
            {
                ShowMsg("请输入窗口号！");
                return;
            }
            if (txtAddress.Text == "")
            {
                ShowMsg("请输入地址!");
            }
            DeviceOR sg = SetValue();

            try
            {
                if (opType == "add")
                {
                     mDA.Insert(sg);
                }
                else
                {
                     mDA.Update(sg);
                }
                IsOK = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        public void ShowMsg(string msg)
        {
            MessageBox.Show(msg,"提示");
        }
    }
}
