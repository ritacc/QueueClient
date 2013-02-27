using System;
using System.Collections.Generic;
using System.Web;
using DBUtility;


namespace QM.Client.DA
{
    public class DALBase
    {
        public MySqlHelper dbMySql = new MySqlHelper();

        public SqlHelper dbSql = new SqlHelper("MySql");

        protected string boolGetFlag(bool v)
        {
            if (v)
                return "1";
            return "0";
        }
    }
}