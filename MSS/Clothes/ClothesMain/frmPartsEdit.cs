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
	public partial class frmPartsEdit : Form
	{
		public frmPartsEdit()
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
		private PartsOR setValue()
		{
			if (string.IsNullOrEmpty(SS.Text)
				 || string.IsNullOrEmpty(CB.Text)
				)
			{
				MessageBox.Show("数据输入不完整。", "提示");
				return null;
			}
			PartsOR m_obj = new PartsOR();
			m_obj.MC = MC.Text;
			m_obj.SS = Convert.ToDouble(SS.Text);
			m_obj.CB = Convert.ToDouble(CB.Text);
			m_obj.LR = m_obj.SS - m_obj.CB;
			m_obj.GHS = GHS.Text;
			m_obj.RQ = XSRQ.Value;
			return m_obj;
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
            PartsOR m_obj = setValue();
            if (m_obj == null)
                return;
            if (m_OpType == "add")
            {
                try
                {
                    new PartsDA().Insert(m_obj);
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
                    new PartsDA().Update(m_obj);
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
		private void frmPartsEdit_Load(object sender, EventArgs e)
		{
			if (m_OpType == "edit")
			{
				loadData();
			}
		}

		private void loadData()
		{
			PartsOR m_obj = new PartsDA().selectARowDate(m_ID);

			MC.Text = m_obj.MC;
			SS.Text = m_obj.SS.ToString();
			CB.Text = m_obj.CB.ToString();


			GHS.Text = m_obj.GHS;
			XSRQ.Value = m_obj.RQ;
		}
	}
}
