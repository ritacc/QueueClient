using System;
using System.Collections.Generic;
using System.Text;

namespace DBUtility
{
    /// <summary>
    /// 
    /// </summary>
   public class MySqlHelper : DbHelper
    {
       /// <summary>
       /// 
       /// </summary>
       public MySqlHelper()
            : base()
        {

        }

        /// <summary>
        /// SqlHelper 构造方法
        /// </summary>
        /// <param name="name">数据库名</param>
       public MySqlHelper(string name)
            : base(name)
        {

        }
    }
}
