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
                //只更新自己网点数据
                _BussCon.UpdateEmployee();
                _BussCon.UpdateSysPara();
                _BussCon.UpdatePageWin();
                _BussCon.UpdateQhandy();
                _BussCon.UpdateShutdownTime();
                _BussCon.UpdateWindow();
                _BussCon.UpdateNearbyInfo();

                //继承关系统
                _BussCon.UpdateBussinessRole();
                _BussCon.UpdateBussinessRoleON();
                _BussCon.UpdateEmployType();
                _BussCon.UpdateSmsPeople();
                _BussCon.UpdateVIPCardKey();
                _BussCon.UpdateVipCardType();

                

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
