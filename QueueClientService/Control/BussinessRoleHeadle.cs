using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QM.Client.Entity;
using QM.Client.DA.MySql;

namespace QM.Client.WebService.Control
{
    public class BussinessRoleHeadle
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        public List<BussinessRoleOnBussOR> BussinessRoleList { get; set; }

        public void Init()
        {
            BussinessRoleList = new BussinessRoleMySqlDA().selectAllBussinessRoleOnBuss();
            BussinessRoleONMySqlDA buOnDA = new BussinessRoleONMySqlDA();
            foreach (BussinessRoleOnBussOR obj in BussinessRoleList)
            {
                obj.BussRoleOnList = buOnDA.selectRolesONByRoleID(obj.Id);
            }
        }

        public BussinessRoleOnBussOR GetBussinessRole(string mid)
        {
            foreach (BussinessRoleOnBussOR obj in BussinessRoleList)
            {
                if (obj.Id == mid)
                    return obj;
            }
            return null;
        }

        public List<BussinessRoleONOR> GetBussinessRoleOn(EmployeeOR empobj, WindowOR winobj)
        {
            string strRoleID = string.Empty;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    strRoleID = winobj.Role;
                    break;
                case DayOfWeek.Tuesday:
                    strRoleID = winobj.Jca2;
                    break;
                case DayOfWeek.Wednesday:
                    strRoleID = winobj.Jca3;
                    break;
                case DayOfWeek.Thursday:
                    strRoleID = winobj.Jca4;
                    break;
                case DayOfWeek.Friday:
                    strRoleID = winobj.Jca5;
                    break;
                case DayOfWeek.Saturday:
                    strRoleID = winobj.Jca6;
                    break;
                case DayOfWeek.Sunday:
                    strRoleID = winobj.Jca7;
                    break;
            }

            BussinessRoleOnBussOR windowRole = null;
            if (!string.IsNullOrEmpty(strRoleID))
            {
                windowRole = GetBussinessRole(strRoleID);
            }

            BussinessRoleOnBussOR empRole = null;
            if (!string.IsNullOrEmpty(empobj.Highrole))
            {
                empRole = GetBussinessRole(empobj.Highrole);
            }
            return CombinRole(windowRole, empRole);
        }

        public List<BussinessRoleONOR> CombinRole(BussinessRoleOnBussOR windowRole, BussinessRoleOnBussOR empRole)
        {
            if (windowRole == null && empRole == null)
                return null;
            if (windowRole == null || empRole == null)
            {
                if (windowRole == null)
                    return empRole.BussRoleOnList;
                if (empRole == null)
                    return windowRole.BussRoleOnList;
            }

            List<BussinessRoleONOR> list = new List<BussinessRoleONOR>();
            foreach (BussinessRoleONOR w in windowRole.BussRoleOnList)
            {
                foreach (BussinessRoleONOR e in empRole.BussRoleOnList)
                {
                    if (w.Bussinessid == e.Bussinessid)
                    {
                        list.Add(e);
                        break;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取 队列角色优先时间
        /// </summary>
        /// <param name="list"></param>
        /// <param name="bussinessID"></param>
        /// <returns></returns>
        public int GetRoleFirstTimeLent(List<BussinessRoleONOR> list, string bussinessID)
        {
            foreach (BussinessRoleONOR obj in list)
            {
                if (obj.Bussinessid == bussinessID)
                {
                    if (obj.IsBackupPrio)  //备用队列
                    {
                        return obj.Backuppriortimes * 60;
                    }
                    else
                    {
                        return obj.Priortimes * 60;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// 业务是否可办理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="bussinessID"></param>
        /// <returns></returns>
        public bool BussinessIsEnableHeadle(List<BussinessRoleONOR> list, string bussinessID
            , List<WindowLoginInfoOR> ListWindowLogins)
        {
            foreach (BussinessRoleONOR obj in list)
            {
                if (obj.Bussinessid == bussinessID)
                {
                    if (obj.IsBackupPrio)  //备用队列
                    {
                        //检查，备用队列，是否有用户可以办理
                        if (CheckBackupPrio(obj.Bussinessid, ListWindowLogins))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 检查备用队列是否有其它窗口在办理
        /// </summary>
        /// <param name="bussinessid"></param>
        /// <returns></returns>
        private bool CheckBackupPrio(string bussinessid, List<WindowLoginInfoOR> ListWindowLogins)
        {
            foreach (WindowLoginInfoOR obj in ListWindowLogins)
            {
                if (obj.Status == 0 && obj.BussinessRoleOn != null)
                {
                    foreach (BussinessRoleONOR busson in obj.BussinessRoleOn)
                    {
                        if (busson.Bussinessid == bussinessid && !busson.IsBackupPrio)
                            return true;
                    }
                }
            }
            return false;
        }
    }

}