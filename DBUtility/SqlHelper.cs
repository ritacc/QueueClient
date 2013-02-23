using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBUtility
{
    /// <summary>
    /// SQL Server ���ݿ⴦���࣬������ҳ����
    /// </summary>
    public class SqlHelper : DbHelper
    {
        /// <summary>
        /// SqlHelper ���췽��
        /// </summary>
        public SqlHelper()
            : base()
        {

        }

        /// <summary>
        /// SqlHelper ���췽��
        /// </summary>
        /// <param name="name">���ݿ���</param>
        public SqlHelper(string name)
            : base(name)
        {

        }

        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="sql">SQL �ű�</param>
        /// <param name="pageIndex">ҳ����(��1��ʼ)</param>
        /// <param name="pageSize">��ҳ��С</param>
        /// <param name="recordCurrent">�ܵļ�¼����</param>
        /// <returns>���ز�ѯ��� DataTable</returns>
        public override DataTable ExecuteQuery(string sql, int pageIndex, int pageSize, out int recordCurrent)
        {
            string procedureName = "Spy_Page";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sql", sql)
                ,new SqlParameter("@PageCurrent", pageIndex)
                ,new SqlParameter("@PageSize", pageSize)
                ,new SqlParameter("@RecordCount", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            DataTable dt = base.ExecuteQueryDataSetProc(procedureName, parameters).Tables[1];
            recordCurrent = Convert.ToInt32(parameters[3].Value);
            return dt;
        }
    }
}
