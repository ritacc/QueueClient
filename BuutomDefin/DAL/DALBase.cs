using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;




namespace QM.DAL
{
    public class DALBase
    {
        protected OracleHelper db = new OracleHelper();
        //protected SqlHelper dbcus = new SqlHelper("cusomp");
       
        protected void resetDB()
        {
            try
            {
               // db.Dispose();
            }
            catch (Exception ex)
            {             
                throw ex;
            }
        }
    }
}
