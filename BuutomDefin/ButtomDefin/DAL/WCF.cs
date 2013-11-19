using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
namespace ButtomDefin.DAL
{
    public class WCF
    {
        public static WCFSV.BottomDAClient GetQueueButtom()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            EndpointAddress address = new EndpointAddress(
                new Uri(Application.Current.Host.Source, "../WCF/BottomDA.svc"));
            try
            {
                return new WCFSV.BottomDAClient(binding, address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
