using System;
using System.Collections.Generic;
using System.Web;
using DBUtility;


namespace QM.Client.DA
{
    public class DALBase
    {
        protected MySqlHelper dbMySql = new MySqlHelper("MySql");

        protected SqlHelper dbMsSql = new SqlHelper("Queue");

        protected string boolGetFlag(bool v)
        {
            if (v)
                return "1";
            return "0";
        }
    }
}