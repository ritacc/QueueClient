using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSClass.Entity;
using MSSClass.Dal;
using MSSClass;

namespace Clothes.SellingClothes
{
    public partial class SellClothe : Form
    {
        SellclothesDA sellClothDal = new SellclothesDA();
        string m_SelectID = string.Empty;//ѡ����ID

        public SellClothe()
        {
            InitializeComponent();
        }

        private void SellClothe_Load(object sender, EventArgs e)
        {           
           BindGridView();
        }

        private void BindGridView()
        {
            try
            {
                string where = string.Format(" selltime>=#{0} 00:00:00# and selltime<=#{1} 23:59:59#", dtpSellDt.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"));
                DataTable dt = sellClothDal.selectViewData(where);
                this.GdTodayList.DataSource = dt;


                DataTable dataCount = sellClothDal.selectCountData(where);
                //purchaseCount,sum(sellPrice) as sellPriceCount,sum(profit) as profitCount
                if (dataCount.Rows.Count == 0)
                    lblShowMsg.Text = "";
                else
                {
                    string value = string.Format("{0},��{1}���۽�{2}\t���ɱ���{3}\t������{4}", this.dtpSellDt.Text, dtpEnd.Text, dataCount.Rows[0]["sellPriceCount"].ToString(),
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

      
       
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="str">��������</param>
        private void showMsg(string str)
        {
            str = str.Replace("'", "");
            MessageBox.Show(str, "��ʾ");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SellClotheEdit edit = new SellClotheEdit();
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
                MessageBox.Show("��ѡ���¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = gv[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("��ѡ���¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("��ѡ���¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = gv[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("��ѡ���¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("��ȷ��Ҫɾ���˼�¼��", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    sellClothDal.Delete(id);
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