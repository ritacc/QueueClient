using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class QhImgSetDA : DALBase
    {
        /// <summary>
        /// 查询取号图片配置
        /// </summary>
        /// <returns></returns>
        public string GetValue(string strKey)
        {
            string sql = string.Format("select * from t_clientsyspara where KeyWord='{0}'",strKey);

            DataTable dt = null;
            try
            {
                dt = dbMySql.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count == 0)
                return string.Empty;
            return dt.Rows[0]["Value"].ToString();
        }


        /// <summary>
        /// 修改图片设置
        /// </summary>
        /// <param name="imgname"></param>
        /// <returns></returns>
        public bool UpdateImgPassword(string newimgname,string newpwd)
        {
            if (string.IsNullOrEmpty(newimgname))
            {
                return false;
            }
            string strimg = GetValue("ImageSet");
            string strpwd = GetValue("pwd");
            if (strimg == newimgname && newpwd == strpwd)
                return true;

            if (string.IsNullOrEmpty(strimg))
            {
                string sql = GetInsert("ImageSet", newimgname);
                 dbMySql.ExecuteNoQuery(sql);
            }
            else
            {
                string sql = GetUpdate("ImageSet", newimgname);
                 dbMySql.ExecuteNoQuery(sql);
            }

            if (string.IsNullOrEmpty(strpwd))
            {
                string sql = GetInsert("pwd", newpwd);
                dbMySql.ExecuteNoQuery(sql);
            }
            else
            {
                string sql = GetUpdate("pwd", newpwd);
                dbMySql.ExecuteNoQuery(sql);
            }

            return true;
        }
        private string GetInsert(string strKey, string strValue)
        {
            return string.Format("insert into t_clientsyspara (KeyWord,Value,AlertDate) values('{0}','{1}',now())",
                strKey, strValue);
        }
        private string GetUpdate(string strKey, string strValue)
        {
            return string.Format("update t_clientsyspara set Value='{0}',AlertDate=now() where KeyWord='{1}'",
                 strValue, strKey);
        }

    }
}
