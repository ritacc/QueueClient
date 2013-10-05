using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    public class DeviceOR 
    {

        private string _Id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;               
            }
        }

        private int _Devicetypeid;
        /// <summary>
        /// 
        /// </summary>
        public int Devicetypeid
        {
            get { return _Devicetypeid; }
            set
            {
                _Devicetypeid = value;              
            }
        }

        private string _Windowno;
        /// <summary>
        /// 
        /// </summary>
        public string Windowno
        {
            get { return _Windowno; }
            set
            {
                _Windowno = value;
            }
        }

        private string _Windowtype;
        /// <summary>
        /// 
        /// </summary>
        public string Windowtype
        {
            get { return _Windowtype; }
            set
            {
                _Windowtype = value;
            }
        }

        private string _Devicemodel;
        /// <summary>
        /// 
        /// </summary>
        public string Devicemodel
        {
            get { return _Devicemodel; }
            set
            {
                _Devicemodel = value;
            }
        }

        private string _Hostaddr;
        /// <summary>
        /// 
        /// </summary>
        public string Hostaddr
        {
            get { return _Hostaddr; }
            set
            {
                _Hostaddr = value;
            }
        }

        private string _Address;
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                
            }
        }

        private int _Status;
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                
            }
        }

        /// <summary>
        /// 状态显示
        /// </summary>
        public string StatusShow { get; set; }

        private DateTime _Updatetime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Updatetime
        {
            get { return _Updatetime; }
            set
            {
                _Updatetime = value;
                
            }
        }

        private DateTime _Createtime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Createtime
        {
            get { return _Createtime; }
            set
            {
                _Createtime = value;
                
            }
        }

        public int? RowNumber { get; set; }
        public int? ColNumber { get; set; }

        /// <summary>
        /// device构造函数
        /// </summary>
        public DeviceOR()
        {
            Createtime = DateTime.Now;
            Updatetime = DateTime.Now;
        }

        /// <summary>
        /// device构造函数
        /// </summary>
        public DeviceOR(DataRow row)
        {
            // 
            _Id = row["ID"].ToString().Trim();
            // 
            _Devicetypeid = Convert.ToInt32(row["DeviceTypeID"]);
            // 
            _Windowno = row["WindowNo"].ToString().Trim();
            // 
            _Windowtype = row["WindowType"].ToString().Trim();
            // 
            _Devicemodel = row["DeviceModel"].ToString().Trim();
            // 
            _Hostaddr = row["HostAddr"].ToString().Trim();
            // 
            _Address = row["Address"].ToString().Trim();
            // 
            _Status = Convert.ToInt32(row["Status"]);
            // 
            _Updatetime = Convert.ToDateTime(row["UpdateTime"]);
            // 
            _Createtime = Convert.ToDateTime(row["CreateTime"]);

            if (row["rowNumber"].ToString() != "")
            {
                RowNumber = Convert.ToInt32(row["rowNumber"].ToString());
            }

            if (row["ColNumber"].ToString() != "")
            {
                ColNumber = Convert.ToInt32(row["ColNumber"].ToString());
            }
            //StatusShow = row["StatusShow"].ToString();

        }

    }
}
