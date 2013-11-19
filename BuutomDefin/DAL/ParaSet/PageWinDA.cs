using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using QM.Entity.ParaSet;


namespace QM.DAL.ParaSet
{
    /// <summary>
    /// 
    /// </summary>
    public class PageWinDA : DALBase
    {

        #region 查询
        public List<PageWinOR> selectPageWinsByWdbh(string wdbh)
        {
            string sql =string.Format( "select * from t_PageWin where orgbh='{0}'",wdbh);
            
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<PageWinOR> listPage = new List<PageWinOR>();
            foreach (DataRow dr in dt.Rows)
            {
                PageWinOR obj = new PageWinOR(dr);
                listPage.Add(obj);
            }
            return listPage;
        }

        public PageWinOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_PageWin where  Id='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
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
            PageWinOR m_Page = new PageWinOR(dr);
            return m_Page;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_PageWin
        /// </summary>
        public virtual bool Insert(PageWinOR pageWin)
        {
            string sql = "insert into t_PageWin (Id, Name, Width, Height, orgBH) values (@Id, @Name, @Width, @Height, @orgBH)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, pageWin.Id),
				new SqlParameter("@Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Default, pageWin.Name),
				new SqlParameter("@Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Width", DataRowVersion.Default, pageWin.Width),
				new SqlParameter("@Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Height", DataRowVersion.Default, pageWin.Height),
				new SqlParameter("@orgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "orgBH", DataRowVersion.Default, pageWin.Orgbh)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_PageWin
        /// </summary>
        public virtual bool Update(PageWinOR pageWin)
        {
            string sql = "update t_PageWin set  Name = @Name,  Width = @Width,  Height = @Height where  Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, pageWin.Id),
				new SqlParameter("@Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Default, pageWin.Name),
				new SqlParameter("@Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Width", DataRowVersion.Default, pageWin.Width),
				new SqlParameter("@Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Height", DataRowVersion.Default, pageWin.Height)
				//new SqlParameter("@orgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "orgBH", DataRowVersion.Default, pageWin.Orgbh)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_PageWin
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from t_PageWin where  Id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", strId);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

