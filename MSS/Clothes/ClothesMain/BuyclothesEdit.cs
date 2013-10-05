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
    public partial class BuyclothesEdit : Form
    {
        public BuyclothesEdit()
        {
            InitializeComponent();
        }


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

        private void BuyclothesEdit_Load(object sender, EventArgs e)
        {
            if (m_OpType == "edit")
            {
                loadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BuyclothesOR affe = setValue();
            if (m_OpType == "add")
            {
                try
                {
                    new BuyclothesDA().Insert(affe);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                }
            }
            else if (m_OpType == "edit")
            {
                try
                {
                    affe.Id = int.Parse(m_ID);
                    new BuyclothesDA().Update(affe);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                }
            }
            _IsReutrn = true;
            
        }

        private void clear()
        {
            txtClothesbh.Text = "";//
            txtBuywhere.Text = "";//
            txtPrice.Text = "";//
            txtRemark.Text ="";//
        }

        private void loadData()
        {
            BuyclothesOR m_Buyc = new BuyclothesDA().selectARowDate(m_ID);            
            txtClothesbh.Text = m_Buyc.Clothesbh;//
            txtBuywhere.Text = m_Buyc.Buywhere;//
            txtPrice.Text = m_Buyc.Price.ToString();//
            txtRemark.Text = m_Buyc.Remark;//
            dtpBuydata.Text = m_Buyc.Buydata;//

        }

        private BuyclothesOR setValue()
        {
            BuyclothesOR m_Buyc = new BuyclothesOR();
          
            m_Buyc.Clothesbh = txtClothesbh.Text;//
            m_Buyc.Buywhere = txtBuywhere.Text;//
            m_Buyc.Price = float.Parse(txtPrice.Text);//
            m_Buyc.Remark = txtRemark.Text;//
            m_Buyc.Buydata = dtpBuydata.Text;//

            return m_Buyc;
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

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}