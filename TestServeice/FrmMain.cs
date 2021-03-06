﻿using System;
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

        private void btnGetAllBussiness_Click(object sender, EventArgs e)
        {
            try
            {
                QueueClient.QueueClientSoapClient v = Init();
                this.dataGridView1.DataSource = v.getQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCH_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
           string mbill= v.BussinessQH(txtBussinessID.Text, "");
           
           //MessageBox.Show(
           //    string.Format("当前所取到的票号：{0}", mbill)
           //    );
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
           string value= v.getCall("CALL", txtWindowNo.Text);
           //MessageBox.Show(value);
           lblBill.Text = value;
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            string value = v.getCall("WELCOME", txtBill.Text);
            MessageBox.Show(value);
        }

        private void btnGetQueues_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            rtbMsg.Text = v.getBussinessInfo(txtBussinessID.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            MessageBox.Show(v.getLogin(txtEmployeeNo.Text, "", txtWindowNo.Text));
        }

        private void btnJudge_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            string value = v.getCall("JUDGE", txtBill.Text);
            MessageBox.Show(value);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            string value = v.endService(txtEmployeeNo.Text,txtWindowNo.Text);
            MessageBox.Show(value);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            string value = v.getCall("PAUSE", txtWindowNo.Text);
            MessageBox.Show(value);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            QueueClient.QueueClientSoapClient v = Init();
            string value = v.getCall("RESTART", txtWindowNo.Text);
            MessageBox.Show(value);
        }
    }
}
