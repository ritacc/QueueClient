using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            _BussCon.UpdateBussiness();
            MessageBox.Show("完成！");
        }
    }
}
