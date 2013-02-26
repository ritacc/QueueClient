﻿using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.DA.MSSql;
using QM.Client.Entity;
using QM.Client.DA.MySql;
using System.Configuration;

namespace QM.Client.UpdateDB
{
    public class BussinessControl
    {
        #region 属性
        public delegate void ShowErrHeader(object sender, string msg);
        public event ShowErrHeader ShowErr;

        /// <summary>
        /// 网点编号: 从配置文件中读取
        /// </summary>
        public string BankNo { get; set; }
        public string BankOrgBH { get; set; }

        public string OrgbhWhere { get; set; }
        #endregion

        #region 初使化
        public bool Init()
        {
            string OrgbhWhere = GetOrgBHWhere();
            if (string.IsNullOrEmpty(OrgbhWhere))
            {
                WriteMsg("0001", "无法获取网点信息，不能更新数据。\r\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示错误或提示信息 
        /// </summary>
        /// <param name="msg"></param>
        protected void OnShowMsg(string msg)
        {
            if (ShowErr != null)
            {
                ShowErr(this, msg);
            }
        }

        private void WriteMsg(string strErrorCode, string msg)
        {
            OnShowMsg(msg);
            WriteLog.writeMsgLog("0001", "无法获取网点信息，不能更新数据。\r\n");
        }



        #region 获取号点orgbh 为条件的数据
        /// <summary>
        /// 根据当前网点的机构编号：获取查询条件(网点的当前级、上一级、到最上层一级)
        /// </summary>
        private string GetOrgBHWhere()
        {
            BankMSSqlDA BankDA = new BankMSSqlDA();
            string orgbhWhere = string.Empty;
            try
            {
                BankNo = ConfigurationManager.AppSettings["BankNo"];
                BankOR _bankOR = BankDA.selectABank(BankNo);
                if (_bankOR == null)
                {
                    string msg = string.Format("无法查询到网点编号为:{0}的信息。", BankNo);
                    WriteMsg("0002", msg);
                    return "";
                }
                BankOrgBH = _bankOR.Orgname;
                orgbhWhere = GetOrgbhWhere("b.orgbh", BankOrgBH);
            }
            catch (Exception ex)
            {
                WriteMsg("0003", ex.Message);
            }
            return orgbhWhere;
        }

        /// <summary>
        /// 根据当前网点的机构编号：获取查询条件(网点的当前级、上一级、到最上层一级)
        /// </summary>
        /// <param name="Filds"></param>
        /// <param name="strOrgbh"></param>
        /// <returns></returns>
        private string GetOrgbhWhere(string Filds, string strOrgbh)
        {
            string dataArea = strOrgbh;
            if (string.IsNullOrEmpty(dataArea))
                throw new Exception("获取用户数据范围失败！");
            if (dataArea.Length == 6)
                return string.Format("{0}='{1}'", Filds, dataArea);
            string strWhere = string.Format(" {0}='{1}'", Filds, dataArea);
            int ForLen = dataArea.Length / 6;
            for (int i = 1; i < ForLen; i++)
            {
                int RemoveLen = dataArea.Length - i * 6;
                strWhere = string.Format(" {0} or {1}='{2}'", strWhere, Filds, dataArea.Substring(0, RemoveLen));
            }
            return string.Format("({0})", strWhere);
        }
        #endregion
        #endregion


        #region 更新数据
        /// <summary>
        ///  业务类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateBussiness()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;
            
            BussinessMSSqlDA mssqlBus = new BussinessMSSqlDA();
            List<BussinessOR> listBuss = mssqlBus.selectBankData(OrgbhWhere);
            WriteMsg("0000", string.Format("查询到业务类型数据：{0}条",listBuss.Count));
            BussinessMySqlDA mysqlBus = new BussinessMySqlDA();
            mysqlBus.UpdateBussiness(listBuss);
            return true;
        }



        /// <summary>
        /// 更新柜员
        /// </summary>
        /// <returns></returns>
        public bool UpdateEmployee()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            return true;
        }

        /// <summary>
        /// 更新窗口页
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageWin()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;


            return true;
        }

        #endregion
    }
}
