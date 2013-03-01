using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class EmployeeMySqlDA : DALBase
    {
        public EmployeeOR SelectAEmployeeLogin(string userID, string pwd)
        {
            string sql =string.Format( "select * from t_Employee where EmployNo='{0}' ",userID);
            DataTable dt = dbMySql.ExecuteQuery(sql);

            if (dt == null)
                return null;
            if (dt.Rows.Count > 0)
                return new EmployeeOR(dt.Rows[0]);
            return null;
        }

        #region 更新 柜员
        public void UpdateEmployee(List<EmployeeOR> listemployee)
        {
            string sql = "truncate table t_Employee";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (EmployeeOR obj in listemployee)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(EmployeeOR employee)
        {
            string sql = @"insert into t_Employee (Id,Name,EmployNo,EmployType,HighRole,
LowRole,Description,OrgBH)
values ('@Id','@Name','@EmployNo','@EmployType','@HighRole',
'@LowRole','@Description','@OrgBH')";
            sql = sql.Replace("@Id", employee.Id);	//
            sql = sql.Replace("@Name", employee.Name);	//姓名
            sql = sql.Replace("@EmployNo", employee.Employno);	//柜员编号
            sql = sql.Replace("@EmployType", employee.Employtype);	//外键，关联到表t_EmployType中
            sql = sql.Replace("@HighRole", employee.Highrole);	//默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示高柜业务角色
            sql = sql.Replace("@LowRole", employee.Lowrole);	//默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示低柜业务角色
            sql = sql.Replace("@Description", employee.Description);	//描述
            sql = sql.Replace("@OrgBH", employee.Orgbh);	//机构编号

            return sql;
        }
        #endregion

    }
}
