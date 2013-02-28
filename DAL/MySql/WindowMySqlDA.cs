using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class WindowMySqlDA : DALBase
    {
        #region 更新
        public void UpdateWindow(List<WindowOR> listwindow)
        {
            string sql = "truncate table t_Window";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (WindowOR obj in listwindow)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(WindowOR window)
        {
            string sql = @"insert into t_Window (Id,Name,Role,SoundDev,Description,
OrgBH)
values ('@Id','@Name','@Role',SoundDev,'@Description',
'@OrgBH')";
            sql = sql.Replace("@Id", window.Id);	//
            sql = sql.Replace("@Name", window.Name);	//窗口名称
            sql = sql.Replace("@Role", window.Role);	//业务角色
            sql = sql.Replace("@SoundDev", window.Sounddev.ToString());	//声音设备
            sql = sql.Replace("@Description", window.Description);	//描述
            sql = sql.Replace("@OrgBH", window.Orgbh);	//机构

            return sql;
        }
        #endregion

    }
}

