using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

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
            string sql = @"insert into t_Window (Id,Name,SoundDev,Description,OrgBH,
Role,JCA2,JCA3,JCA4,JCA5,JCA6,JCA7)
values ('@Id','@Name',SoundDev,'@Description','@OrgBH',
'@Role','@JCA2','@JCA3','@JCA4','@JCA5','@JCA6','@JCA7')";
            sql = sql.Replace("@Id", window.Id);	//
            sql = sql.Replace("@Name", window.Name);	//窗口名称
            sql = sql.Replace("@SoundDev", window.Sounddev.ToString());	//声音设备
            sql = sql.Replace("@Description", window.Description);	//描述
            sql = sql.Replace("@OrgBH", window.Orgbh);	//机构
            sql = sql.Replace("@Role", window.Role);	//周一柜台角色
            sql = sql.Replace("@JCA2", window.Jca2);	//周二柜台角色
            sql = sql.Replace("@JCA3", window.Jca3);	//周三柜台角色
            sql = sql.Replace("@JCA4", window.Jca4);	//周四柜台角色
            sql = sql.Replace("@JCA5", window.Jca5);	//周五柜台角色
            sql = sql.Replace("@JCA6", window.Jca6);	//周六柜台角色
            sql = sql.Replace("@JCA7", window.Jca7);	//周日柜台角色

            return sql;
        }
        #endregion

        public WindowOR SelectWindowByNo(string windowNo)
        {
            string sql = string.Format(@"select fjq.Address fjqAddress,pjq.Address pjqAddress
,tp.Address tpAddress,w.* from t_window w
left join t_device fjq on w.name=fjq.WindowNo and fjq.DeviceTypeID=1
left join t_device pjq on w.name=pjq.WindowNo and pjq.DeviceTypeID=3
left join t_device tp on w.name=tp.WindowNo and tp.DeviceTypeID=2 where w.Name='{0}' ", windowNo);
            DataTable dt = dbMySql.ExecuteQuery(sql);

            if (dt == null)
                return null;
            if (dt.Rows.Count > 0)
                return new WindowOR(dt.Rows[0]);
            return null;
        }

        public List<WindowOR> SelectWindows()
        {
            string sql = @"select fjq.Address fjqAddress,pjq.Address pjqAddress
,tp.Address tpAddress,w.* from t_window w
left join t_device fjq on w.name=fjq.WindowNo and fjq.DeviceTypeID=1
left join t_device pjq on w.name=pjq.WindowNo and pjq.DeviceTypeID=3
left join t_device tp on w.name=tp.WindowNo and tp.DeviceTypeID=2 
order by name";
            DataTable dt = dbMySql.ExecuteQuery(sql);

            if (dt == null)
                return null;
            List<WindowOR> listWindow = new List<WindowOR>();
            foreach (DataRow dr in dt.Rows)
            {
                listWindow.Add( new WindowOR(dr));
            }
            return listWindow;

        }

        

    }
}

