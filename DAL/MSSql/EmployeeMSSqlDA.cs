using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QM.Client.Entity;

namespace QM.Client.DA.MSSql
{
   public class EmployeeMSSqlDA:DALBase
   {
       public List<EmployeeOR> selectEmployeeData(string orgbhWhere)
       {
           if (string.IsNullOrEmpty(orgbhWhere))
               return null;

           string sql = @"select bu.* from t_Employee bu
inner join t_Bank b on b.orgbh= bu.orgbh where " + orgbhWhere;
           DataTable dt = null;
           try
           {
               dt = dbMsSql.ExecuteQuery(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           if (dt == null)
               return null;
           List<EmployeeOR> listEmp = new List<EmployeeOR>();
           foreach (DataRow dr in dt.Rows)
           {
               EmployeeOR obj = new EmployeeOR(dr);
               listEmp.Add(obj);
           }
           return listEmp;
       }

    }
}
