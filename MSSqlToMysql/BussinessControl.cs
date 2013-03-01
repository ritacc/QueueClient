using System;
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

        public BankOR BankInfo { get; set; }

        /// <summary>
        /// 机构编号条件(当前级上级网点)
        /// </summary>
        public string OrgbhWhere { get; set; }

        /// <summary>
        /// 自己网点
        /// </summary>
        public string OrgbhWhereSelf { get; set; }
        #endregion

        #region 初使化
        public bool Init()
        {
            GetOrgBHWhere();
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

        private void WriteMsg(string strErrorCode, string msg, bool isAddLine = false)
        {
            OnShowMsg(msg);
            WriteLog.writeMsgLog(strErrorCode, msg, isAddLine);
        }



        #region 获取号点orgbh 为条件的数据
        /// <summary>
        /// 根据当前网点的机构编号：获取查询条件(网点的当前级、上一级、到最上层一级)
        /// </summary>
        private void GetOrgBHWhere()
        {
            BankMSSqlDA BankDA = new BankMSSqlDA();

            try
            {
                BankNo = ConfigurationManager.AppSettings["BankNo"];
                BankOR _bankOR = BankDA.selectABank(BankNo);
                BankInfo = _bankOR;

                if (_bankOR == null)
                {
                    string msg = string.Format("无法查询到网点编号为:{0}的信息。", BankNo);
                    WriteMsg("0002", msg);
                }

                OrgbhWhere = GetOrgbhWhere("b.orgbh", BankInfo.Orgbh);
                OrgbhWhereSelf = string.Format("b.orgbh='{0}'", BankInfo.Orgbh);
                WriteMsg("0000", string.Format("机构编号：{0},机构名称：{1}", _bankOR.Orgbh, _bankOR.Orgname));
            }
            catch (Exception ex)
            {
                WriteMsg("0003", ex.Message);
            }

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
        #region 继承关系
        /// <summary>
        /// 更新网点数据。
        /// </summary>
        /// <returns></returns>
        public bool UpdateBank()
        {
            if (BankNo == null)
            {
                WriteMsg("0000", "网点信息为空。");
                return false;
            }
            try
            {
                WriteMsg("0000", "开始更新“网点”", true);
                new BankMySqlDA().UpdateBank(BankInfo);
                WriteMsg("0000", "更新 网点 信息成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        /// <summary>
        ///  业务类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateBussiness()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;
            try
            {
                WriteMsg("0000", "开始更新“业务类型”", true);

                BussinessMSSqlDA mssqlBus = new BussinessMSSqlDA();
                List<BussinessOR> listBuss = mssqlBus.selectBankData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到业务类型数据：{0}条", listBuss.Count));
                BussinessMySqlDA mysqlBus = new BussinessMySqlDA();
                mysqlBus.UpdateBussiness(listBuss);
                WriteMsg("0000", "更新业务类型成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }
        public bool UpdateBussinessRole()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“业务角色”", true);

                BussinessRoleMSSqlDA mssqlBuss = new BussinessRoleMSSqlDA();
                List<BussinessRoleOR> listBuss = mssqlBuss.selectBussinessRoleData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 BussinessRole 数量：{0}条", listBuss.Count));

                BussinessRoleMySqlDA mysqlBuss = new BussinessRoleMySqlDA();
                mysqlBuss.UpdateBussinessRole(listBuss);
                WriteMsg("0000", "更新 BussinessRole 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }
        public bool UpdateBussinessRoleON()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“业务角色详细”", true);

                BussinessRoleONMSSqlDA mssqlBuss = new BussinessRoleONMSSqlDA();
                List<BussinessRoleONOR> listBuss = mssqlBuss.selectBussinessRoleONData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 BussinessRoleON 数量：{0}条", listBuss.Count));

                BussinessRoleONMySqlDA mysqlBuss = new BussinessRoleONMySqlDA();
                mysqlBuss.UpdateBussinessRoleON(listBuss);
                WriteMsg("0000", "更新 BussinessRoleON 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }




        public bool UpdateEmployType()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“柜员”", true);

                EmployTypeMSSqlDA mssqlEmpl = new EmployTypeMSSqlDA();
                List<EmployTypeOR> listEmpl = mssqlEmpl.selectEmployTypeData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 EmployType 数量：{0}条", listEmpl.Count));

                EmployTypeMySqlDA mysqlEmpl = new EmployTypeMySqlDA();
                mysqlEmpl.UpdateEmployType(listEmpl);
                WriteMsg("0000", "更新 EmployType 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateSmsPeople()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“SnmpEople”", true);

                SmsPeopleMSSqlDA mssqlSmsP = new SmsPeopleMSSqlDA();
                List<SmsPeopleOR> listSmsP = mssqlSmsP.selectSmsPeopleData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 SmsPeople 数量：{0}条", listSmsP.Count));

                SmsPeopleMySqlDA mysqlSmsP = new SmsPeopleMySqlDA();
                mysqlSmsP.UpdateSmsPeople(listSmsP);
                WriteMsg("0000", "更新 SmsPeople 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateVIPCardKey()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“VIPCardKey”", true);

                VIPCardKeyMSSqlDA mssqlVIPC = new VIPCardKeyMSSqlDA();
                List<VIPCardKeyOR> listVIPC = mssqlVIPC.selectVIPCardKeyData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 VIPCardKey 数量：{0}条", listVIPC.Count));

                VIPCardKeyMySqlDA mysqlVIPC = new VIPCardKeyMySqlDA();
                mysqlVIPC.UpdateVIPCardKey(listVIPC);
                WriteMsg("0000", "更新 VIPCardKey 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateVipCardType()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“Vip类型”", true);

                VipCardTypeMSSqlDA mssqlVipC = new VipCardTypeMSSqlDA();
                List<VipCardTypeOR> listVipC = mssqlVipC.selectVipCardTypeData(OrgbhWhere);
                WriteMsg("0000", string.Format("查询到 VipCardType 数量：{0}条", listVipC.Count));

                VipCardTypeMySqlDA mysqlVipC = new VipCardTypeMySqlDA();
                mysqlVipC.UpdateVipCardType(listVipC);
                WriteMsg("0000", "更新 VipCardType 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }
        #endregion
        #region 只更新自己网点数据

        /// <summary>
        /// 更新柜员
        /// </summary>
        /// <returns></returns>
        public bool UpdateEmployee()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;
            try
            {
                WriteMsg("0000", "开始更新“柜员”", true);

                EmployeeMSSqlDA mssqlEmp = new EmployeeMSSqlDA();
                List<EmployeeOR> listEmp = mssqlEmp.selectEmployeeData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 柜员 数量：{0}条", listEmp.Count));

                EmployeeMySqlDA mysqlEmp = new EmployeeMySqlDA();
                mysqlEmp.UpdateEmployee(listEmp);
                WriteMsg("0000", "更新 柜员 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        /// <summary>
        /// 更新页窗口
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageWin()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“页窗口”", true);

                PageWinMSSqlDA mssqlPage = new PageWinMSSqlDA();
                List<PageWinOR> listPage = mssqlPage.selectPageWinData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 PageWin 数量：{0}条", listPage.Count));

                PageWinMySqlDA mysqlPage = new PageWinMySqlDA();
                mysqlPage.UpdatePageWin(listPage);
                WriteMsg("0000", "更新 PageWin 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateQhandy()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“Qhandy”", true);

                QhandyMSSqlDA mssqlQhan = new QhandyMSSqlDA();
                List<QhandyOR> listQhan = mssqlQhan.selectQhandyData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 Qhandy 数量：{0}条", listQhan.Count));

                QhandyMySqlDA mysqlQhan = new QhandyMySqlDA();
                mysqlQhan.UpdateQhandy(listQhan);
                WriteMsg("0000", "更新 Qhandy 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateShutdownTime()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“关机时间”", true);

                ShutdownTimeMSSqlDA mssqlShut = new ShutdownTimeMSSqlDA();
                List<ShutdownTimeOR> listShut = mssqlShut.selectShutdownTimeData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 ShutdownTime 数量：{0}条", listShut.Count));

                ShutdownTimeMySqlDA mysqlShut = new ShutdownTimeMySqlDA();
                mysqlShut.UpdateShutdownTime(listShut);
                WriteMsg("0000", "更新 ShutdownTime 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }
        public bool UpdateSysPara()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“参数设置”", true);

                SysParaMSSqlDA mssqlSysP = new SysParaMSSqlDA();
                List<SysParaOR> listSysP = mssqlSysP.selectSysParaData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 SysPara 数量：{0}条", listSysP.Count));

                SysParaMySqlDA mysqlSysP = new SysParaMySqlDA();
                mysqlSysP.UpdateSysPara(listSysP);
                WriteMsg("0000", "更新 SysPara 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        public bool UpdateWindow()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“窗口”", true);

                WindowMSSqlDA mssqlWind = new WindowMSSqlDA();
                List<WindowOR> listWind = mssqlWind.selectWindowData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 Window 数量：{0}条", listWind.Count));

                WindowMySqlDA mysqlWind = new WindowMySqlDA();
                mysqlWind.UpdateWindow(listWind);
                WriteMsg("0000", "更新 Window 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }


        public bool UpdateNearbyInfo()
        {
            if (string.IsNullOrEmpty(OrgbhWhere))
                return false;

            try
            {
                WriteMsg("0000", "开始更新“监控网点”", true);

                NearbyInfoMSSqlDA mssqlNear = new NearbyInfoMSSqlDA();
                List<NearbyInfoOR> listNear = mssqlNear.selectNearbyInfoData(OrgbhWhereSelf);
                WriteMsg("0000", string.Format("查询到 NearbyInfo 数量：{0}条", listNear.Count));

                NearbyInfoMySqlDA mysqlNear = new NearbyInfoMySqlDA();
                mysqlNear.UpdateNearbyInfo(listNear);
                WriteMsg("0000", "更新 NearbyInfo 成功。");
            }
            catch (Exception ex)
            {
                WriteMsg("", ex.Message);
            }
            return true;
        }

        #endregion
        #endregion
    }
}
