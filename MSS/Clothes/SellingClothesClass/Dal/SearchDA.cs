using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MSSClass.DBCommon;

namespace MSSClass.Dal
{
    public class SearchDA
    {
        CommonDB db = new CommonDB();
        public DataTable selectViewData(string where, string where1)
        {
            string sql = string.Format(@"select 
JX as [名称],
SS as [实收],
CB as [成本],
LR as [利润], 
GHS as [供货商], 
XSRQ as [销售日期]
from phone where {0}
union all
select
MC as [名称],
SS as [实收],
CB as [成本],
LR as [利润], 
GHS as [供货商],
RJ as [销售日期]
from Parts where {1}
union all
select
MC as [名称],
SS as [实收],
CB as [成本],
LR as [利润], 
GHS as [供货商],
RJ as [销售日期]
from Maintain where {1}
", where
 , where1);

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


        public DataTable selectCountData(string where, string where1)
        {
            string sql = string.Format(@"select sum(CB) as purchaseCount,sum(SS) as sellPriceCount,sum(LR) as profitCount from
(
select
SS,
CB,
LR
from phone   where {0}
union all
select
SS,
CB,
LR
from Parts   where {1}
union all
select 
SS,
CB,
LR
from Maintain where {1}
) as Item ", where
  , where1);
            
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
    }
}
