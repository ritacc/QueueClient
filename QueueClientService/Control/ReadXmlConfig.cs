using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using QM.Client.Entity;

namespace QM.Client.WebService.Control
{
    public class ReadXmlConfig
    {
        public ConfigOR Read()
        {
            
            string ConfigPath = string.Format("{0}\\config.xml", Common.GetPath());
            if (!File.Exists(ConfigPath))
            {
                ErrorLog.WriteLog("ReadXmlConfig#Read", "配置文件不存在.");
                return null;
            }
             XmlDocument xmlDoc = new XmlDocument();
             try
             {
                 xmlDoc.Load(ConfigPath);
             }
             catch (Exception ex)
             {
                 ErrorLog.WriteLog("", ex.Message);
             }

             XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//
             ConfigOR config = new ConfigOR();
             foreach (XmlNode xn in nodeList)
             {
                 if (xn is XmlElement)
                 {
                     XmlElement xe = (XmlElement)xn;

                     switch (xe.Name)
                     {
                         case "tp_4_adv":
                             config.tp_4_adv = xe.InnerText;
                             break;
                         case "tp_5_adv":
                             config.tp_5_adv = xe.InnerText;
                             break;
                         case "tp_8_adv":
                             config.tp_8_adv = xe.InnerText;
                             break;

                         case "tp_8_show":
                             config.tp_8_show = xe.InnerText;
                             break;

                         case "zhp_4_adv":
                             config.zhp_4_adv = xe.InnerText;
                             break;
                         case "zhp_5_adv":
                             config.zhp_5_adv = xe.InnerText;
                             break;
                         case "zhp_8_adv":
                             config.zhp_8_adv = xe.InnerText;
                             break;

                         case "volume":
                             int itemp = 5;
                             if (int.TryParse(xe.InnerText, out itemp))
                             {
                                 config.volume = itemp;
                             }
                             else
                             {
                                 config.volume = 7;
                             }
                             break;
                     }

                 }
             }
            return config;
        }
    }
}