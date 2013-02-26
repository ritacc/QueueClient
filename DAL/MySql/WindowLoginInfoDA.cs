using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
  public  class WindowLoginInfoDA:DALBase
    {

      /// <summary>
      /// 查询当前登录窗口的柜员
      /// </summary>
      /// <returns></returns>
      public List<WindowLoginInfoOR> SelectToDayLogins()
      {

          List<WindowLoginInfoOR> listLogins = new List<WindowLoginInfoOR>();
          string sql = string.Format("select * from t_WindowLoginInfo where  logintime > '{0} 00:00:00' and status != 1 ",
              DateTime.Now.ToString("yyyy-MM-dd"));
          DataTable dt = dbMySql.ExecuteQuery(sql);
          foreach (DataRow dr in dt.Rows)
          {
              WindowLoginInfoOR obj = new WindowLoginInfoOR(dr);
              listLogins.Add(obj);
          }
          return listLogins;
      }
    }
}
