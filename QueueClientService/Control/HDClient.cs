using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ServiceModel.Configuration;
using QM.Client.WebService.HD;
using System.ServiceModel;

namespace QM.Client.WebService.Control
{
    public class HDClient
    {
        public void HD()
        {
            
        }
        private static readonly HDClient _instance = new HDClient();
        public static HDClient Instance { get { return _instance; } }

        protected ControllerSoapClient _HDSoapClient;

        public ControllerSoapClient GetHDClient()
        {
            if (_HDSoapClient == null)
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MaxReceivedMessageSize = 2147483647;
                binding.MaxBufferSize = 2147483647;
                EndpointAddress address = new EndpointAddress(this.GetHDURL());
                _HDSoapClient= new ControllerSoapClient(binding, address);
            }
            return _HDSoapClient;
        }

        private Uri GetHDURL()
        {
            Configuration config = //new Configuration();
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup svcmod = (ServiceModelSectionGroup)config.GetSectionGroup("system.serviceModel");
            if (svcmod.Client.Endpoints.Count == 0)
                throw new Exception("配置文件:Endpoint节点不存在！");
            return svcmod.Client.Endpoints[0].Address;
        }


    }
}