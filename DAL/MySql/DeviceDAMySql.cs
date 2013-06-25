using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class DeviceDAMySql : DALBase
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<DeviceOR> SelectAllDevices()
        {
            string sql = "select * from t_device";
            DataTable dt = null;
            try
            {
                dt = dbMySql.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            List<DeviceOR> listDevi = new List<DeviceOR>();
            foreach (DataRow dr in dt.Rows)
            {
                DeviceOR m_devi = new DeviceOR(dr);
                listDevi.Add(m_devi);
            }
            return listDevi;
        }

        /// <summary>
        /// 更新设备状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public bool UpdateDeviceStatus(string id, int Status)
        {
            string sql = string.Format("update t_device set Status={0},UpdateTime='{1}' where  Id='{2}'",
                Status,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                id);
            return dbMySql.ExecuteNoQuery(sql) > 0;
        }


        public DataTable SelectDeviceByTypeID(int DeviceType)
        {
            string sql = string.Format(@"select d.*,case when d.status=1 then '正常' else '异常' end statusShow 
from t_device d where DeviceTypeID={0} order by Windowno,Address", DeviceType);
            DataTable dt = dbMySql.ExecuteQuery(sql);
            return dt;
        }

        public DeviceOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_device where  Id='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = dbMySql.ExecuteQueryDataSet(sql).Tables[0];
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
            DeviceOR m_devi = new DeviceOR(dr);
            return m_devi;

        }


        public int DataCountAdd(DeviceOR mobj)
        {
            string sql = string.Format("select count(*) from t_device where DeviceTypeID={0}  and (Windowno='{1}' or Address='{2}')"
                , mobj.Devicetypeid, mobj.Windowno, mobj.Address);
            if (mobj.Devicetypeid == DeviceType.DeviceType_ZP)
                sql = string.Format("select count(*) from t_device where DeviceTypeID={0}   and Address='{1}'"
                , mobj.Devicetypeid,  mobj.Address);
            try
            {
                int count = Convert.ToInt32(dbMySql.ExecuteScalar(sql).ToString());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DataCountAlter(DeviceOR mobj)
        {
            string sql = string.Format("select count(*) from t_device where DeviceTypeID={0}  and (Windowno='{1}' or Address='{2}') and id<> '{3}'"
                , mobj.Devicetypeid, mobj.Windowno, mobj.Address,mobj.Id);
            if(mobj.Devicetypeid== DeviceType.DeviceType_ZP)
                sql = string.Format("select count(*) from t_device where DeviceTypeID={0}  and  Address='{1}' and id<> '{2}'"
                , mobj.Devicetypeid, mobj.Windowno, mobj.Address, mobj.Id);
            try
            {
                int count = Convert.ToInt32(dbMySql.ExecuteScalar(sql).ToString());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public bool Insert(DeviceOR device)
        {
            if (DataCountAdd(device) > 0)
            {
                throw new Exception("包含重复数据！");
            }
            string sql = @"insert into t_device (ID,DeviceTypeID,WindowNo,WindowType,DeviceModel,
HostAddr,Address,Status,UpdateTime,CreateTime)
values ('@ID',@DeviceTypeID,'@WindowNo','@WindowType','@DeviceModel',
'@HostAddr','@Address',0,'@UpdateTime','@CreateTime')";
            sql = sql.Replace("@ID", device.Id);	//
            sql = sql.Replace("@DeviceTypeID", device.Devicetypeid.ToString());	//
            sql = sql.Replace("@WindowNo", device.Windowno);	//
            sql = sql.Replace("@WindowType", device.Windowtype);	//
            sql = sql.Replace("@DeviceModel", device.Devicemodel);	//
            sql = sql.Replace("@HostAddr", device.Hostaddr);	//
            sql = sql.Replace("@Address", device.Address);	//
            sql = sql.Replace("@Status", device.Status.ToString());	//
            sql = sql.Replace("@UpdateTime", device.Updatetime.ToString("yyyy-MM-dd HH:mm:ss"));	//
            sql = sql.Replace("@CreateTime", device.Createtime.ToString("yyyy-MM-dd HH:mm:ss"));	//

            return dbMySql.ExecuteNoQuery(sql) > 0;
        }


        public bool Update(DeviceOR device)
        {
            if (DataCountAlter(device) > 0)
            {
                throw new Exception("包含重复数据！");
            }

            string sql = @"update t_device set WindowNo='@WindowNo'
,WindowType='@WindowType'
,DeviceModel='@DeviceModel'
,HostAddr='@HostAddr'
,Address='@Address'
,UpdateTime='@UpdateTime'  where ID='@ID'";
            
            sql = sql.Replace("@ID", device.Id);	//
            sql = sql.Replace("@DeviceTypeID", device.Devicetypeid.ToString());	//
            sql = sql.Replace("@WindowNo", device.Windowno);	//
            sql = sql.Replace("@WindowType", device.Windowtype);	//
            sql = sql.Replace("@DeviceModel", device.Devicemodel);	//
            sql = sql.Replace("@HostAddr", device.Hostaddr);	//
            sql = sql.Replace("@Address", device.Address);	//
            
            sql = sql.Replace("@UpdateTime", device.Updatetime.ToString("yyyy-MM-dd HH:mm:ss"));	//
            

            return dbMySql.ExecuteNoQuery(sql) > 0;
        }

        public bool Delete(string m_id)
        {
            string sql = string.Format("delete from t_device where  Id='{0}'", m_id);

            return dbMySql.ExecuteNoQuery(sql) > 0;
        }

        

    }
}
