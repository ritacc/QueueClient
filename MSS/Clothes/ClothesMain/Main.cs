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

        }

       
        #region 手机
        PhoneDA mPhoneDA = new PhoneDA();
        private void BindGridView()
        {
            try
            {
                string where = string.Format(" XSRQ>=#{0} 00:00:00# and XSRQ<=#{1} 23:59:59#", dtpSellDt.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"));
                DataTable dt = mPhoneDA.selectViewData(where);
                this.GdTodayList.DataSource = dt;


                DataTable dataCount = mPhoneDA.selectCountData(where);
                 
                if (dataCount.Rows.Count == 0)
                    lblShowMsg.Text = "";
                else
                {
                    string value = string.Format("{0},到{1}销售金额：{2}\t，成本：{3}\t，利润：{4}", this.dtpSellDt.Text, dtpEnd.Text, 
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
        #endregion

        private void btnSellPhone_Click(object sender, EventArgs e)
        {

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

        

        
    }

     
}