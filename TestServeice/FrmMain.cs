using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.ServiceModel;


namespace TestServeice
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public QueueClient.QueueClientSoapClient Init()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            EndpointAddress address = new EndpointAddress(
                new Uri("http://localhost:1298/QueueClient.asmx", UriKind.Absolute));

            QueueClient.QueueClientSoapClient v = new QueueClient.QueueClientSoapClient(binding, address);
            return v;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // QueueClient.QueueClientSoapClient v = Init();
           //QueueClient.BussinessOR[] obj= v.HelloWorld();
           //this.dataGridView1.DataSource = obj;
        }
    }
}
