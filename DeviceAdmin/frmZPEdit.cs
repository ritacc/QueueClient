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
    public partial class frmZPEdit : Form
    {
        public frmZPEdit()
        {
            InitializeComponent();
        }

        private void frmZPEdit_Load(object sender, EventArgs e)
        {
            if (opType != "add")
            {
                LoadData();
            }
            txtTypeName.Text = DeviceType.GetTypeName(Devicetypeid);
        }

        public string DeviceID { get; set; }
        private int Devicetypeid = DeviceType.DeviceType_ZP;

        public bool IsOK { get; set; }

        public string opType { get; set; }

        DeviceDAMySql mDA = new DeviceDAMySql();
        private void LoadData()
        {
            try
            {
                DeviceOR m_devi = mDA.selectARowDate(DeviceID);

             
                txtDevicemodel.Text = m_devi.Devicemodel;//
                txtHostaddr.Text = m_devi.Hostaddr;//
                txtAddress.Text = m_devi.Address;//
                txtColNumber.Text = m_devi.ColNumber.HasValue ? m_devi.ColNumber.Value.ToString() : "";
                txtRowNumber.Text = m_devi.RowNumber.HasValue ? m_devi.RowNumber.Value.ToString() : "";
                
            }
            catch (Exception e)
            {
                ShowMsg(e.Message);
            }
        }


        private DeviceOR SetValue()
        {
            DeviceOR m_devi = new DeviceOR();
            if (opType == "add")
                m_devi.Id = Guid.NewGuid().ToString();
            else
                m_devi.Id = DeviceID;

            m_devi.Devicetypeid = Devicetypeid;//
            m_devi.Windowno = "";//
            m_devi.Windowtype = "";//
            m_devi.Devicemodel = txtDevicemodel.Text;//
            m_devi.Hostaddr = txtHostaddr.Text;//
            m_devi.Address = txtAddress.Text;//
            m_devi.RowNumber = Convert.ToInt32(txtRowNumber.Text);
            m_devi.ColNumber = Convert.ToInt32(txtColNumber.Text);
            return m_devi;
        }

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtAddress.Text == "")
            {
                ShowMsg("请输入地址!");
                return;
            }
            if (txtRowNumber.Text == "")
            {
                ShowMsg("请输入行数!");
                return;
            }
            if (txtColNumber.Text == "")
            {
                ShowMsg("请输入行字数。");
                return;
            }
            int Test = 0;
            if (!int.TryParse(txtRowNumber.Text, out Test) || !int.TryParse(txtColNumber.Text, out Test))
            {
                ShowMsg("输入行数或行字数不正确。");
                return;
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
            MessageBox.Show(msg, "提示");
        }
    }
}
