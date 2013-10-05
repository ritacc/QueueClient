using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OR;
using MSSClass.DBCommon;


namespace MSSClass.Dal
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemsetDA
    {
        CommonDB db = new CommonDB();

        #region 查询
        public DataTable selectAllDateByWhere(string where)
        {
            string sql = "select * from SystemSet";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;            
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public SystemsetOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from SystemSet where string strId='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            SystemsetOR m_Syst = new SystemsetOR(dr);
            return m_Syst;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入SystemSet
        /// </summary>
        public virtual bool Insert(SystemsetOR systemset)
        {
            string sql = "insert into SystemSet (id, keyWord, keyName) values (:id, :keyWord, :keyName)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter(":id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "id", DataRowVersion.Default, systemset.Id),
				new SqlParameter(":keyWord", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "keyWord", DataRowVersion.Default, systemset.Keyword),
				new SqlParameter(":keyName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "keyName", DataRowVersion.Default, systemset.Keyname)
			};
            return db.excuteNonquery(sql);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新SystemSet
        /// </summary>
        public virtual bool Update(SystemsetOR systemset)
        {
            string sql = "update SystemSet set  id = :id,  keyWord = :keyWord,  keyName = :keyName where  ID = :ID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter(":id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "id", DataRowVersion.Default, systemset.Id),
				new SqlParameter(":keyWord", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "keyWord", DataRowVersion.Default, systemset.Keyword),
				new SqlParameter(":keyName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "keyName", DataRowVersion.Default, systemset.Keyname)
			};
            return db.excuteNonquery(sql);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除SystemSet
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from SystemSet where  ID = :ID";
            SqlParameter parameter = new SqlParameter(":ID", strId);
            return db.excuteNonquery(sql);
        }
        #endregion
    }
}

