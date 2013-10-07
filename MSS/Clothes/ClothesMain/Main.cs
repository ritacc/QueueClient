using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSClass.Entity;
using System.Data.OleDb;
using MSSClass.DBCommon;
using MSSClass.Dal;
using MSSClass;
using MSS;

namespace Clothes.SellingClothes
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
			BindPartsGridView();
			BindGridView();
			BindMaintainGridView();
        }

       
        #region 手机
        PhoneDA mPhoneDA = new PhoneDA();
        private void BindGridView()
        {
            try
            {
                string where = string.Format(" XSRQ>=#{0} 00:00:00# and XSRQ<=#{1} 23:59:59#", dtpPhoneStart.Value.ToString("yyyy-MM-dd"), dtpPhoneEnd.Value.ToString("yyyy-MM-dd"));
                DataTable dt = mPhoneDA.selectViewData(where);
                this.dgPhone.DataSource = dt;
				 

                DataTable dataCount = mPhoneDA.selectCountData(where);
                 
                if (dataCount.Rows.Count == 0)
                    lblShowMsg.Text = "";
                else
                {
                    string value = string.Format("{0},到{1}销售金额：{2}\t，成本：{3}\t，利润：{4}", this.dtpPhoneStart.Text, dtpPhoneEnd.Text, 
                        dataCount.Rows[0]["sellPriceCount"].ToString(),
                        dataCount.Rows[0]["purchaseCount"].ToString(),
                        dataCount.Rows[0]["profitCount"].ToString());
                    lblShowMsg.Text = value;
                }
            }
            catch (System.Exception ex)
            {
                Error.WriteLog("SellClothe : Form:BindGridView(),001", "0001", ex.Message);
            }



        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			frmPhoneEdit edit = new frmPhoneEdit();
			edit.Owner = this;
			edit.OpType = "add";
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgPhone.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			frmPhoneEdit edit = new frmPhoneEdit();
			edit.OpType = "edit";
			edit.ID = id;
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgPhone.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("你确定要删除此记录吗？", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					new PhoneDA().Delete(id);
					BindGridView();
				}
				catch (Exception ex)
				{
					showMsg(ex.Message);
				}
			}
		}
        #endregion
		
		#region Parts
		PartsDA mPartsDA = new PartsDA();
		private void BindPartsGridView()
		{
			try
			{
				string where = string.Format(" XSRQ>=#{0} 00:00:00# and XSRQ<=#{1} 23:59:59#", dptPartsStart.Value.ToString("yyyy-MM-dd"), dtpPartsEnd.Value.ToString("yyyy-MM-dd"));
				DataTable dt = mPartsDA.selectViewData(where);
				this.dgParts.DataSource = dt;

				
					
				DataTable dataCount = mPartsDA.selectCountData(where);

				if (dataCount.Rows.Count == 0)
					lblShowMsg.Text = "";
				else
				{
					string value = string.Format("{0},到{1}销售金额：{2}\t，成本：{3}\t，利润：{4}", this.dptPartsStart.Text, dtpPartsEnd.Text,
						dataCount.Rows[0]["sellPriceCount"].ToString(),
						dataCount.Rows[0]["purchaseCount"].ToString(),
						dataCount.Rows[0]["profitCount"].ToString());
					lblShowMsg.Text = value;
				}
			}
			catch (System.Exception ex)
			{
				Error.WriteLog("SellClothe : Form:BindGridView(),001", "0001", ex.Message);
			}



		}
		private void btnPartsSearch_Click(object sender, EventArgs e)
		{
			BindPartsGridView();
		}

		private void btnPartsAdd_Click(object sender, EventArgs e)
		{
			frmPartsEdit edit = new frmPartsEdit();
			edit.Owner = this;
			edit.OpType = "add";
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnPartsEdit_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgParts.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			frmPartsEdit edit = new frmPartsEdit();
			edit.OpType = "edit";
			edit.ID = id;
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnPartsDelete_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgParts.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("你确定要删除此记录吗？", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					new PartsDA().Delete(id);
					BindPartsGridView();
				}
				catch (Exception ex)
				{
					showMsg(ex.Message);
				}
			}
		}
		#endregion

		#region Maintain
		MaintainDA mMaintainDA = new MaintainDA();
		private void BindMaintainGridView()
		{
			try
			{
				string where = string.Format(" XSRQ>=#{0} 00:00:00# and XSRQ<=#{1} 23:59:59#", dtpMantainStart.Value.ToString("yyyy-MM-dd"), dtpMantainEnd.Value.ToString("yyyy-MM-dd"));
				DataTable dt = mMaintainDA.selectViewData(where);
				this.dgMaintain.DataSource = dt;
				
				
				DataTable dataCount = mMaintainDA.selectCountData(where);

				if (dataCount.Rows.Count == 0)
					lblShowMsg.Text = "";
				else
				{
					string value = string.Format("{0},到{1}销售金额：{2}\t，成本：{3}\t，利润：{4}", this.dtpMantainStart.Text, dtpPhoneEnd.Text,
						dataCount.Rows[0]["sellPriceCount"].ToString(),
						dataCount.Rows[0]["purchaseCount"].ToString(),
						dataCount.Rows[0]["profitCount"].ToString());
					lblShowMsg.Text = value;
				}
			}
			catch (System.Exception ex)
			{
				Error.WriteLog("SellClothe : Form:BindGridView(),001", "0001", ex.Message);
			}



		}
		private void btnMaintainSearch_Click(object sender, EventArgs e)
		{
			BindMaintainGridView();
		}

		private void btnMaintainAdd_Click(object sender, EventArgs e)
		{
			frmMaintainEdit edit = new frmMaintainEdit();
			edit.Owner = this;
			edit.OpType = "add";
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnMaintainEdit_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgMaintain.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			frmMaintainEdit edit = new frmMaintainEdit();
			edit.OpType = "edit";
			edit.ID = id;
			edit.ShowDialog();
			if (edit.IsReutrn)
				BindGridView();
		}

		private void btnMaintainDelete_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection gv = this.dgMaintain.SelectedRows;
			if (gv.Count == 0)
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string id = gv[0].Cells[0].Value.ToString();
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("请选择记录？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("你确定要删除此记录吗？", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					new MaintainDA().Delete(id);
					BindMaintainGridView();
				}
				catch (Exception ex)
				{
					showMsg(ex.Message);
				}
			}
		}

		#endregion

		#region Common
		/// <summary>
        /// 弹出窗体
        /// </summary>
        /// <param name="str">弹出内容</param>
        private void showMsg(string str)
        {
            str = str.Replace("'", "");
            MessageBox.Show(str, "提示");
		}

		#endregion




	}

     
}