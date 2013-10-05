using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSClass.Entity;
using MSSClass.Dal;

namespace Clothes.SellingClothes
{
    public partial class SellClotheEdit : Form
    {
        public SellClotheEdit()
        {
            InitializeComponent();
        }
        SellclothesDA sellClothDal = new SellclothesDA();
        #region 属性
        private string m_OpType = string.Empty;
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OpType
        {
            set { m_OpType = value; }
        }

        string m_ID;
        /// <summary>
        /// 操作ID
        /// </summary>
        public string ID
        {
            set { m_ID = value; }
        }

        private bool _IsReutrn = false;

        public bool IsReutrn
        {
            get { return _IsReutrn; }
        }
        #endregion
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SellclothesOR affe = setValue();
            SellclothesDA dal = new SellclothesDA();
            if (m_OpType == "add")
            {
                try
                {
                    dal.Insert(affe);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                    _IsReutrn = false;
                    return;
                }
                showMsg("添加成功");

            }
            else if (m_OpType == "edit")
            {
                try
                {
                    affe.Id = m_ID;
                    dal.Update(affe);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                    _IsReutrn = false;
                    return;
                }
                showMsg("修改成功");
            }
            _IsReutrn = true;
            this.Close();
        }

        private void SellClotheEdit_Load(object sender, EventArgs e)
        {
            string where = " keyword='sellClothes'";
            DataTable sysSet = new SystemsetDA().selectAllDateByWhere(where);
            cbSellType.DataSource = sysSet;
            cbSellType.DisplayMember = "keyName";

            if (m_OpType == "edit")
            {
                loadData();
            }
        }

        private void loadData()
        {

            SellclothesOR m_Sell = sellClothDal.selectARowDate(m_ID);
            
            cbSellType.Text = m_Sell.Selltype;//
            txtClotheno.Text = m_Sell.Clotheno;//
            txtClothename.Text = m_Sell.Clothename;//
            txtPurchaseprice.Text = m_Sell.Purchaseprice;//
            txtPurchasecountprice.Text = m_Sell.Purchasecountprice.ToString();//
            txtSellprice.Text = m_Sell.Sellprice.ToString();//
            txtProfit.Text = m_Sell.Profit.ToString();//
            txtRemark.Text = m_Sell.Remark;
            dateTimePicker1.Text = m_Sell.Selltime;
        }

        private SellclothesOR setValue()
        {
            SellclothesOR m_Sell = new SellclothesOR();// m_Sell.Id = txtId.Text;//
            try
            {
                m_Sell.Selltype =cbSellType.Text;//
                m_Sell.Clotheno = txtClotheno.Text;//
                m_Sell.Clothename = txtClothename.Text;//
                m_Sell.Purchaseprice = txtPurchaseprice.Text;//
                m_Sell.Purchasecountprice = float.Parse(txtPurchasecountprice.Text);//
                m_Sell.Sellprice = float.Parse(txtSellprice.Text);//
                m_Sell.Profit = float.Parse(txtProfit.Text);//
                m_Sell.Selltime = dateTimePicker1.Text;
                m_Sell.Remark = txtRemark.Text;
            }
            catch (Exception ex)
            {
                showMsg("请输入正确的信息！");
            }
            return m_Sell;
        }

        #region 文本值
        private void priceChange()
        {
            if (!string.IsNullOrEmpty(txtPurchasecountprice.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtSellprice.Text.Trim()))
                {
                    float allcountN = 0;
                    float sellPrice = 0;
                    if (float.TryParse(txtPurchasecountprice.Text, out allcountN) && float.TryParse(txtSellprice.Text, out sellPrice))
                    {
                        txtProfit.Text = (sellPrice - allcountN).ToString();
                    }
                }
            }
        }

        private void txtSellprice_TextChanged(object sender, EventArgs e)
        {
            priceChange();
        }

        private void txtPurchasecountprice_TextChanged(object sender, EventArgs e)
        {
            priceChange();
        }

        private void txtPurchaseprice_TextChanged(object sender, EventArgs e)
        {
            string txtValue = txtPurchaseprice.Text.Trim();
            if (!string.IsNullOrEmpty(txtValue))
            {
                if (txtValue.IndexOf(",") > 0)
                {
                    float fTemp = 0;
                    string[] arr = txtValue.Split(',');
                    float aountPrice = 0;
                    foreach (string str in arr)
                    {

                        if (!string.IsNullOrEmpty(str) && float.TryParse(str, out fTemp))
                        {
                            aountPrice += fTemp;
                        }
                        else
                        {
                            return;
                        }
                    }
                    txtPurchasecountprice.Text = aountPrice.ToString();
                }
                else
                {
                    float aountPrice = 0;
                    if (float.TryParse(txtPurchaseprice.Text.Trim(), out aountPrice))
                    {
                        txtPurchasecountprice.Text = txtPurchaseprice.Text.Trim();
                    }
                }
            }// end if

        }
        #endregion
        /// <summary>
        /// 弹出窗体
        /// </summary>
        /// <param name="str">弹出内容</param>
        private void showMsg(string str)
        {
            str = str.Replace("'", "");
            MessageBox.Show(str, "提示");
        }

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}