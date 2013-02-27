using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using QM.Client.DA.MSSql;
using QM.Client.Entity;

namespace QM.Client.UpdateDB
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
       

        private void btnBussiness_Click(object sender, EventArgs e)
        {
            BussinessControl _BussCon = new BussinessControl();
            _BussCon.ShowErr += new BussinessControl.ShowErrHeader(BussCon_ShowErr);
            if (_BussCon.Init())
            {
                _BussCon.UpdateBussiness();

                _BussCon.UpdateBank();
                _BussCon.UpdateEmployee();

                BussCon_ShowErr(null, "更新完成。");
            }


            
        }

        public void BussCon_ShowErr(object sender, string msg)
        {
            rtbMsg.AppendText(msg);
            rtbMsg.AppendText("\r\n");
        }

       
    }
}
