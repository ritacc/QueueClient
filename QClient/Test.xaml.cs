using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QClient.HD;
using QClient.Core.Uitl.Logger;

namespace QClient
{
    /// <summary>
    /// Test.xaml 的交互逻辑
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ControllerSoapClient HDClient = new ControllerSoapClient();

            ErrorLog.WriteLog("InitDevice：", "011");
            string Result = HDClient.InitDevice(1, "011");
            ErrorLog.WriteLog("InitDevice：_Result", Result);

            ErrorLog.WriteLog("GetDeviceStatus：", "011");
             Result = HDClient.GetDeviceStatus(1, "011", 0, 0, 10);
            ErrorLog.WriteLog("GetDeviceStatus：_Result", Result);

            string fjqAddress = "011";
            for (int i = 0; i < 10; i++)
            {
                ErrorLog.WriteTestLog("#CheckMsg#", "GetDeviceMSG Address" + fjqAddress);
                string Msg = HDClient.GetDeviceMSG(1, fjqAddress, 10);
                ErrorLog.WriteTestLog("#CheckMsg#", Msg);
            }
        }
    }
}
