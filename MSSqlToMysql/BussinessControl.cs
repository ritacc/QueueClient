using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.DA.MSSql;
using QM.Client.Entity;
using QM.Client.DA.MySql;

namespace QM.Client.UpdateDB
{
   public class BussinessControl
    {
       /// <summary>
       /// 从服务器上更新 业务类型
       /// </summary>
       /// <returns></returns>
       public bool UpdateBussiness()
       {
           BussinessMSSqlDA mssqlBus = new BussinessMSSqlDA();
           List<BussinessOR> listBuss = mssqlBus.selectAllDate();

           BussinessMySqlDA mysqlBus = new BussinessMySqlDA();
           mysqlBus.UpdateBussiness(listBuss);
           return true;
       }
    }
}
