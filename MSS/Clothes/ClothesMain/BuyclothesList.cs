using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSClass.Dal;

namespace Clothes.SellingClothes
{
    public partial class BuyclothesList : Form
    {
        public BuyclothesList()
        {
            InitializeComponent();
        }
        BuyclothesDA buyClothDal = new BuyclothesDA();
        private void BuyclothesList_Load(object sender, EventArgs e)
        {
            BindGridView();
        }
       

        private void BindGridView()
        {
            string where = string.Format(" buyData>=#{0} 00:00:00# and buyData<=#{1} 23:59:59#", dtpSellDt.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"));
            DataTable dt = buyClothDal.selectAllDateByWhere(where);
            this.GdTodayList.DataSource = dt;


            //DataTable dataCount = sellClothDal.selectCountData(where);
            ////purchaseCount,sum(sellPrice) as sellPriceCount,sum(profit) as profitCount
            //if (dataCount.Rows.Count == 0)
            //    lblShowMsg.Text = "";
            //else
            //{
            //    string value = string.Format("{0}销售金额：{1}\t，成本：{2}\t，利润：{3}", this.dtpSellDt.Text, dataCount.Rows[0]["sellPriceCount"].ToString(),
            //        dataCount.Rows[0]["purchaseCount"].ToString(),
            //        dataCount.Rows[0]["profitCount"].ToString());
            //    lblShowMsg.Text = value;
            //}


        }



        /// <summary>
        /// 弹出窗体
        /// </summary>
        /// <param name="str">弹出内容</param>
        private void showMsg(string str)
        {
            str = str.Replace("'", "");
            MessageBox.Show(str, "提示");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BuyclothesEdit edit = new BuyclothesEdit();
            edit.OpType = "add";
            edit.ShowDialog();
            if (edit.IsReutrn)
                BindGridView();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection gv = this.GdTodayList.SelectedRows;
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

            SellClotheEdit edit = new SellClotheEdit();
            edit.OpType = "edit";
            edit.ID = id;
            edit.ShowDialog();
            if (edit.IsReutrn)
                BindGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection gv = this.GdTodayList.SelectedRows;
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
                    buyClothDal.Delete(id);
                    BindGridView();
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}