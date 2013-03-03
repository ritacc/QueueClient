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
          string sql = string.Format("select * from t_WindowLoginInfo where  logintime > '{0}' and status != 1 order by logintime",
              DateTime.Now.ToString("yyyy-MM-dd"));
          DataTable dt = dbMySql.ExecuteQuery(sql);
          foreach (DataRow dr in dt.Rows)
          {
              WindowLoginInfoOR obj = new WindowLoginInfoOR(dr);
              listLogins.Add(obj);
          }
          return listLogins;
      }

      #region 插入
      public void InsertLoginWindowInfo(WindowLoginInfoOR obj)
      {
          string sql = GetInsertSql(obj);
          dbMySql.ExecuteNoQuery(sql);
      }

      /// <summary>
      /// 获取插入数据
      /// </summary>
      public string GetInsertSql(WindowLoginInfoOR windowlogininfo)
      {
          string sql = @"insert into t_windowlogininfo (ID,LoginTime,WindowNo,EmployNo,EmployName,Status,AlertTime)
values ('@ID',now(),'@WindowNo','@EmployNo','@EmployName',Status,now())";
          sql = sql.Replace("@ID", windowlogininfo.Id);	//
          //sql = sql.Replace("@LoginTime", windowlogininfo.Logintime.ToString("yyyy-MM-dd HH:mm:ss"));	//
          sql = sql.Replace("@WindowNo", windowlogininfo.Windowno);	//
          sql = sql.Replace("@EmployNo", windowlogininfo.Employno);	//
          sql = sql.Replace("@EmployName", windowlogininfo.Employname);	//
          sql = sql.Replace("@Status", windowlogininfo.Status.ToString());	//
          //sql = sql.Replace("@AlertTime", windowlogininfo.Alerttime.ToString("yyyy-MM-dd HH:mm:ss"));	//

          return sql;
      }
      #endregion

      #region 更新 及查询

      #region 查询
      /// <summary>
      /// 查询今天指定窗口登录记录
      /// </summary>
      /// <param name="userID"></param>
      /// <param name="windowID"></param>
      /// <returns></returns>
      public WindowLoginInfoOR SelectLoginLogByUserIDAndWindowID(string userID, string windowID)
      {
          string sql = string.Format(@"select * from t_windowlogininfo where EmployNo='{0}' and WindowNo='{1}'
and status=0 and LoginTime > '{2} 00:00:00'", userID, windowID,DateTime.Now.ToString("yyyy-MM-dd"));
          DataTable dt = dbMySql.ExecuteQuery(sql);

          if (dt.Rows.Count > 0)
              return new WindowLoginInfoOR(dt.Rows[0]);
          return null;
      }

      /// <summary>
      /// 根据用户ID，查询所在登录窗口日志
      /// </summary>
      /// <param name="userID"></param>
      /// <param name="status"></param>
      /// <returns></returns>
      public WindowLoginInfoOR SelectLoginLogByUserID(string userID,string status)
      {
          string sql = string.Format(@"select * from t_windowlogininfo where EmployNo='{0}' 
and status='{1}' and LoginTime > '{2} 00:00:00'", userID, status, DateTime.Now.ToString("yyyy-MM-dd"));
          DataTable dt = dbMySql.ExecuteQuery(sql);

          if (dt.Rows.Count > 0)
              return new WindowLoginInfoOR(dt.Rows[0]);
          return null;
      }
      #endregion

      /// <summary>
      /// 结束服务
      /// </summary>
      /// <param name="_obj"></param>
      /// <returns></returns>
      public bool EndServer(WindowLoginInfoOR _obj)
      {
         return UpdateLoginStatus(_obj);
      }

      /// <summary>
      /// 暂停服务
      /// </summary>
      /// <param name="_obj"></param>
      /// <returns></returns>
      public bool PauseServer(WindowLoginInfoOR _obj)
      {
          return UpdateLoginStatus(_obj);
      }

      /// <summary>
      /// 恢复服务
      /// </summary>
      /// <param name="_obj"></param>
      /// <returns></returns>
      public bool RestarServer(WindowLoginInfoOR _obj)
      {
          return UpdateLoginStatus(_obj);
      }
      /// <summary>
      /// 更新服务状态
      /// </summary>
      /// <param name="_obj"></param>
      /// <returns></returns>
      public bool UpdateLoginStatus(WindowLoginInfoOR _obj)
      {
          string sql = string.Format("update t_windowlogininfo set Status={0} ,AlertTime=now() where id='{1}'"
             , _obj.Status, _obj.Id);
          return dbMySql.ExecuteNoQuery(sql) > 0;
      }

      #endregion



    }
}
