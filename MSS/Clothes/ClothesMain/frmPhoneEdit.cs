using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSClass.Entity;
using MSSClass.Dal;

namespace MSS
{
	public partial class frmPhoneEdit : Form
	{
		public frmPhoneEdit()
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

		private void btnCanncel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private PhoneOR setValue()
		{
			if(string.IsNullOrEmpty( SS.Text)
				 ||  string.IsNullOrEmpty(CB.Text)
				)
			{
				MessageBox.Show("数据输入不完整。","提示");
				return null;
			}
			PhoneOR m_obj = new PhoneOR();
			m_obj.JX = JX.Text;
			m_obj.SS =Convert.ToDouble( SS.Text);
			m_obj.CB = Convert.ToDouble(CB.Text);
			m_obj.LR = m_obj.SS - m_obj.CB;

			m_obj.GHS = GHS.Text;
            m_obj.CH = CH.Text;
			m_obj.GMR = GMR.Text;
            
			m_obj.LXDH = LXDH.Text;
			m_obj.XSRQ = XSRQ.Value;
			m_obj.SHZK = SHZK.Text;

			return m_obj;
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			PhoneOR m_obj = setValue();
			if (m_obj == null)
				return;
            if (m_OpType == "add")
            {
                try
                {
                    new PhoneDA().Insert(m_obj);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                }
            }
            else
            {
                try
                {
                    m_obj.ID = Convert.ToInt32(m_ID);
                    new PhoneDA().Update(m_obj);
                }
                catch (Exception ex)
                {
                    showMsg(ex.Message);
                }
            }
			_IsReutrn = true;
			this.Close();
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
		private void frmPhoneEdit_Load(object sender, EventArgs e)
		{
            if (m_OpType == "edit")
            {
                loadData();
            }
		}

        private void loadData()
        {
            PhoneOR m_obj = new PhoneDA().selectARowDate(m_ID);

            JX.Text=m_obj.JX;
            SS.Text=m_obj.SS.ToString();
            CB.Text = m_obj.CB.ToString();


            GHS.Text=m_obj.GHS;
            CH.Text=m_obj.CH;
            GMR.Text=m_obj.GMR;
            LXDH.Text=m_obj.LXDH;
            XSRQ.Value=m_obj.XSRQ;
            SHZK.Text=m_obj.SHZK;
        }

	}
}
