using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ritacc.ServerAdmin;

namespace ServerInstall
{
   public class SaveConfig
    {

       public void SaveConfigInfo(string strMSSqlCon,string strMySql,
           string mTxtBankno,string QueueUpTimeLen, string UpTimeLen)
       {

           //更新服务配置文件
           string path = Common.GetStartPath(GlobalOR.ServerExeName + ".config");
           ExeConfigurationFileMap map = new ExeConfigurationFileMap();
           map.ExeConfigFilename = path;

           Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
           //实例化mssql
           config.ConnectionStrings.ConnectionStrings["Queue"].ConnectionString = strMSSqlCon;
           config.ConnectionStrings.ConnectionStrings["MySql"].ConnectionString = strMySql;

           config.AppSettings.Settings["Bankno"].Value = mTxtBankno;
           config.AppSettings.Settings["QueueUpTimeLen"].Value = QueueUpTimeLen;
           config.AppSettings.Settings["ParaDownTime"].Value = UpTimeLen;
           config.Save();
           //更新参数配置文件

           //Winform更新数据
           path = Common.GetStartPath("UpdateFrm.exe" + ".config");
           map.ExeConfigFilename = path;
           config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
           //实例化mssql
           config.ConnectionStrings.ConnectionStrings["Queue"].ConnectionString = strMSSqlCon;
           config.ConnectionStrings.ConnectionStrings["MySql"].ConnectionString = strMySql;

           config.AppSettings.Settings["Bankno"].Value = mTxtBankno;
           config.AppSettings.Settings["QueueUpTimeLen"].Value = QueueUpTimeLen;
           config.AppSettings.Settings["ParaDownTime"].Value = UpTimeLen;
           config.Save();

           //DeviceAdmin.exe

           //Winform更新数据
           path = Common.GetStartPath("DeviceAdmin.exe" + ".config");
           map.ExeConfigFilename = path;
           config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
           //实例化mssql
           //config.ConnectionStrings.ConnectionStrings["Queue"].ConnectionString = strMSSqlCon;
           config.ConnectionStrings.ConnectionStrings["MySql"].ConnectionString = strMySql;

           //config.AppSettings.Settings["Bankno"].Value = mTxtBankno;
           //config.AppSettings.Settings["QueueUpTimeLen"].Value = QueueUpTimeLen;
           //config.AppSettings.Settings["ParaDownTime"].Value = UpTimeLen;
           config.Save();
       }

    }
}
