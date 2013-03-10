using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
   public class PageWinMySqlDA:DALBase
    {


        #region 更新业务类型
        public void UpdatePageWin(List<PageWinOR> listpageWin)
        {
            string sql = "truncate table t_PageWin";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (PageWinOR obj in listpageWin)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(PageWinOR pageWin)
        {
            string sql = @"insert into t_PageWin (Id,Name,Width,Height,orgBH) 
values ('@Id','@Name',@Width,@Height,'@orgBH')";
            sql = sql.Replace("@Id", pageWin.Id);	//
            sql = sql.Replace("@Name", pageWin.Name);	//名称
            sql = sql.Replace("@Width", pageWin.Width.ToString());	//宽
            sql = sql.Replace("@Height", pageWin.Height.ToString());	//高
            sql = sql.Replace("@orgBH", pageWin.Orgbh);	//

            return sql;
        }
        #endregion










    }
}
