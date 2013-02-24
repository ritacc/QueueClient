using System.Collections.Generic;
using System.Data;

using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class QClientDA : DALBase
    {
        public PageWinOR GetPageWinId(string id)
        {
            var sql = string.Format("SELECT * FROM T_PAGEWIN WHERE ID = '{0}'", id);
            var dt = dbMySql.ExecuteQuery(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                return new PageWinOR(dt.Rows[0]);
            }
            return null;
        }

        public List<QhandyOR> GetButtonsByPageWinId(string windowID)
        {
            var result = new List<QhandyOR>();
            var sql = string.Format("SELECT * FROM t_qhandy WHERE windowID = '{0}'", windowID);
            var dt = dbMySql.ExecuteQuery(sql);
            if (null != dt)
            {
                foreach(DataRow row in dt.Rows)
                {
                    result.Add(new QhandyOR(row));
                }
            }
            return result;
        }
    }
}
