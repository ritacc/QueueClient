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
        public string selectQhImg()
        {
            string sql = "select * from t_setQhimg";

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
            return dt.Rows[0]["imgname"].ToString();
        }

        /// <summary>
        /// 修改图片设置
        /// </summary>
        /// <param name="imgname"></param>
        /// <returns></returns>
        public bool UpdateImg(string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return false;
            }
            string strimg = selectQhImg();
            if (strimg == imgname)
                return true;
            if (string.IsNullOrEmpty(strimg))
            {
                string sql = string.Format("insert into t_setQhimg values('{0}',now())", imgname);
                return dbMySql.ExecuteNoQuery(sql) > 0;
            }
            else
            {
                string sql = string.Format("update  t_setQhimg set imgName='{0}',alertdate=now()", imgname);
                return dbMySql.ExecuteNoQuery(sql) > 0;
            }
        }

    }
}
