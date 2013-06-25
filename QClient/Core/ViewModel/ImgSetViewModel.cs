using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel.Configuration;
using QClient.Core.Util;
using System.ServiceModel;
using QClient.QueueClinetServiceReference;
using QClient.HD;
using QClient.Core.Uitl.Logger;

namespace QClient.Core.ViewModel
{
  public  class ImgSetViewModel
    {
      private static readonly ImgSetViewModel _instance = new ImgSetViewModel();
      public static ImgSetViewModel Instance { get { return _instance; } }

      #region WebServerice路径
      private Uri _ConfigUrl;
      /// <summary>
      /// WebServerice路径
      /// </summary>
      public Uri ConfigUrl
      {
          get {
              if (_ConfigUrl == null)
                  _ConfigUrl = GetConfigServerURL();

              return _ConfigUrl; 
          }          
      }

      public Uri ConfigHDUrl
      {
          get
          {
              if (_ConfigUrl == null)
                  _ConfigUrl = GetHDURL();
              return _ConfigUrl;
          }
      }

      private Uri GetConfigServerURL()
      {
          //更新服务配置文件
          string mPath = Common.GetStartpath() + "QClient.exe.config";
          if (!System.IO.File.Exists(mPath))
          {
              throw new Exception(string.Format("配置文件:{0}不存在！", mPath));
          }
          ExeConfigurationFileMap map = new ExeConfigurationFileMap();
          map.ExeConfigFilename = mPath;

          Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
          ServiceModelSectionGroup svcmod = (ServiceModelSectionGroup)config.GetSectionGroup("system.serviceModel");
          if(svcmod.Client.Endpoints.Count==0)
              throw new Exception("配置文件:Endpoint节点不存在！");
          return svcmod.Client.Endpoints[0].Address;
      }

      private Uri GetHDURL()
      {
          string mPath = Common.GetStartpath() + "QClient.exe.config";
          if (!System.IO.File.Exists(mPath))
          {
              throw new Exception(string.Format("配置文件:{0}不存在！", mPath));
          }
          ExeConfigurationFileMap map = new ExeConfigurationFileMap();
          map.ExeConfigFilename = mPath;

          Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
          ServiceModelSectionGroup svcmod = (ServiceModelSectionGroup)config.GetSectionGroup("system.serviceModel");
          if (svcmod.Client.Endpoints.Count == 0)
              throw new Exception("配置文件:Endpoint节点不存在！");
          return svcmod.Client.Endpoints[1].Address;
      }
      #endregion

      private QueueClientSoapClient GetClient()
      {
         
          BasicHttpBinding binding = new BasicHttpBinding();
          binding.MaxReceivedMessageSize = 2147483647;
          binding.MaxBufferSize = 2147483647;
          EndpointAddress address = new EndpointAddress(this.ConfigUrl);
          return new QueueClientSoapClient(binding, address);
      }

      private ControllerSoapClient GetHDClient()
      {
          BasicHttpBinding binding = new BasicHttpBinding();
          binding.MaxReceivedMessageSize = 2147483647;
          binding.MaxBufferSize = 2147483647;
          EndpointAddress address = new EndpointAddress(this.GetHDURL());
          return new ControllerSoapClient(binding, address);
          
      }

      public string GetImgSetPath()
      {
          return GetClient().GetClientValue("ImageSet");
      }
      public string GetPwd()
      {
          return GetClient().GetClientValue("pwd");

      }

      public string SetImgPathPassword(string Path, string newPwd)
      {
          return GetClient().UpdateImgPassword(Path, newPwd);
      }

      public string ReadCard()
      {
          try
          {
              ControllerSoapClient client = GetHDClient();
              
              string msg = client.ReadCardData(1, 2, 10);
              return msg;
          }
          catch (Exception ex)
          {
              ErrorLog.WriteLog("ReadCard:", ex.Message);
          }
          return "";
      }

      public bool PrintSlip(string mBillNo)
      {
          ////票号#业务名称#当前业务人数#当前网点人数
          if (string.IsNullOrEmpty(mBillNo))
          {
              return false;
          }
          string[] arr = mBillNo.Split('#');
          if (arr.Length >= 4)
          {

              string Content = "Branch=#Number=<#PH>#BusinessType=<#bussNmae>#Count=<#WaitUserLen>#TipMsg2=#Time=<#Time>#Birthday=##";
              Content.Replace("<#PH>", arr[0])
                  .Replace("Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                  .Replace("<#bussNmae>", arr[1])
              .Replace("<#WaitUserLen>", arr[3]);


              string msg = GetHDClient().PrintSlip(Content, 3);
          }
          return true;
      }
    }
}
