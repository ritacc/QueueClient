using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QM.Client.DA.MySql;
using QM.Client.Entity;


namespace QM.Client.DeviceAdmin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        #region 条屏

        private void btnTPAdd_Click(object sender, EventArgs e)
        {
            frmDeviceEdit frm = new frmDeviceEdit(true);
            frm.Devicetypeid = DeviceType.DeviceType_TP;
            frm.Owner = this;
            frm.opType = "add";
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindTP();
            }
        }

        private void btnTPAlter_Click(object sender, EventArgs e)
        {
            if (gvTP.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            DataGridViewRow gvr = gvTP.SelectedRows[0];

             frmDeviceEdit frm = new frmDeviceEdit(true);
            frm.Devicetypeid = DeviceType.DeviceType_TP;
            frm.Owner = this;
            frm.DeviceID = gvr.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindTP();
            }
        }
        public void ShowMsg(string msg)
        {
            MessageBox.Show(msg, "提示");
        }
        private void btnTPDelete_Click(object sender, EventArgs e)
        {
            if (gvTP.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            if (MessageBox.Show("确定要删除此设备吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            DataGridViewRow gvr = gvTP.SelectedRows[0];
            try
            {
                DeviDA.Delete(gvr.Cells[0].Value.ToString());
                BindTP();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        #endregion

        #region 数据绑定
        private void frmMain_Load(object sender, EventArgs e)
        {
            BindTP();
            BindFJQ();
            BindPJQ();
            BindZP();
        }

        DeviceDAMySql DeviDA = new DeviceDAMySql();
        private void BindTP()
        {
            DataTable dtTP = DeviDA.SelectDeviceByTypeID(DeviceType.DeviceType_TP);
            gvTP.DataSource = dtTP;
        }

        private void BindFJQ()
        {
            DataTable dtFJQ = DeviDA.SelectDeviceByTypeID(DeviceType.DeviceType_FJQ);
            gvFJQ.DataSource = dtFJQ;
        }

        /// <summary>
        /// 评价器
        /// </summary>
        private void BindPJQ()
        {
            DataTable dtPJQ = DeviDA.SelectDeviceByTypeID(DeviceType.DeviceType_PJQ);
            gvPJQ.DataSource = dtPJQ;
        }

        /// <summary>
        /// 主屏
        /// </summary>
        private void BindZP()
        {
            DataTable dtZP = DeviDA.SelectDeviceByTypeID(DeviceType.DeviceType_ZP);
            gvZP.DataSource = dtZP;
        }
        #endregion

        #region 呼号器
        private void btnFJQAdd_Click(object sender, EventArgs e)
        {
            frmDeviceEdit frm = new frmDeviceEdit();
            frm.Devicetypeid = DeviceType.DeviceType_FJQ;
            frm.Owner = this;
            frm.opType = "add";
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindFJQ();
            }
        }

        private void btnFJQAlter_Click(object sender, EventArgs e)
        {
            if (gvFJQ.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            DataGridViewRow gvr = gvFJQ.SelectedRows[0];

            frmDeviceEdit frm = new frmDeviceEdit();
            frm.Devicetypeid = DeviceType.DeviceType_FJQ;
            frm.Owner = this;
            frm.DeviceID = gvr.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindFJQ();
            }
        }

        private void btnFJQDelete_Click(object sender, EventArgs e)
        {
            if (gvFJQ.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            if (MessageBox.Show("确定要删除此设备吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            DataGridViewRow gvr = gvFJQ.SelectedRows[0];
            try
            {
                DeviDA.Delete(gvr.Cells[0].Value.ToString());
                BindFJQ();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        #endregion

        #region 评价器
        private void btnPJQAdd_Click(object sender, EventArgs e)
        {
            frmDeviceEdit frm = new frmDeviceEdit();
            frm.Devicetypeid = DeviceType.DeviceType_PJQ;
            frm.Owner = this;
            frm.opType = "add";
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindPJQ();
            }
        }

        private void btnPJQAlter_Click(object sender, EventArgs e)
        {
            if (gvPJQ.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            DataGridViewRow gvr = gvPJQ.SelectedRows[0];

            frmDeviceEdit frm = new frmDeviceEdit();
            frm.Devicetypeid = DeviceType.DeviceType_PJQ;
            frm.Owner = this;
            frm.DeviceID = gvr.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindPJQ();
            }
        }

        private void btnPJQDelete_Click(object sender, EventArgs e)
        {
            if (gvPJQ.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            if (MessageBox.Show("确定要删除此设备吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            DataGridViewRow gvr = gvPJQ.SelectedRows[0];
            try
            {
                DeviDA.Delete(gvr.Cells[0].Value.ToString());
                BindPJQ();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        #endregion

        #region 主屏
        private void btnZPADD_Click(object sender, EventArgs e)
        {

            frmZPEdit frm = new frmZPEdit();
            frm.Owner = this;
            frm.opType = "add";
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindZP();
            }
        }

        private void btnZPAlter_Click(object sender, EventArgs e)
        {
            if (gvZP.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            DataGridViewRow gvr = gvZP.SelectedRows[0];

            frmZPEdit frm = new frmZPEdit();
            frm.Owner = this;
            frm.DeviceID = gvr.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.IsOK)
            {
                BindZP();
            }
        }

        private void btnZPDelete_Click(object sender, EventArgs e)
        {
            if (gvZP.SelectedRows.Count == 0)
            {
                ShowMsg("请选择设备！");
                return;
            }
            if (MessageBox.Show("确定要删除此设备吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            DataGridViewRow gvr = gvZP.SelectedRows[0];
            try
            {
                DeviDA.Delete(gvr.Cells[0].Value.ToString());
                BindZP();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        #endregion
    }
}
