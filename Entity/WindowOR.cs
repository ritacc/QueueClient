using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowOR
    {

        private string _Id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;
        /// <summary>
        /// 窗口名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Sounddev;
        /// <summary>
        /// 声音设备
        /// </summary>
        public int Sounddev
        {
            get { return _Sounddev; }
            set { _Sounddev = value; }
        }

        private string _Description;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Orgbh;
        /// <summary>
        /// 机构
        /// </summary>
        public string Orgbh
        {
            get { return _Orgbh; }
            set { _Orgbh = value; }
        }

        private string _Role;
        /// <summary>
        /// 周一柜台角色
        /// </summary>
        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private string _Jca2;
        /// <summary>
        /// 周二柜台角色
        /// </summary>
        public string Jca2
        {
            get { return _Jca2; }
            set { _Jca2 = value; }
        }

        private string _Jca3;
        /// <summary>
        /// 周三柜台角色
        /// </summary>
        public string Jca3
        {
            get { return _Jca3; }
            set { _Jca3 = value; }
        }

        private string _Jca4;
        /// <summary>
        /// 周四柜台角色
        /// </summary>
        public string Jca4
        {
            get { return _Jca4; }
            set { _Jca4 = value; }
        }

        private string _Jca5;
        /// <summary>
        /// 周五柜台角色
        /// </summary>
        public string Jca5
        {
            get { return _Jca5; }
            set { _Jca5 = value; }
        }

        private string _Jca6;
        /// <summary>
        /// 周六柜台角色
        /// </summary>
        public string Jca6
        {
            get { return _Jca6; }
            set { _Jca6 = value; }
        }

        private string _Jca7;
        /// <summary>
        /// 周日柜台角色
        /// </summary>
        public string Jca7
        {
            get { return _Jca7; }
            set { _Jca7 = value; }
        }

        /// <summary>
        /// Window构造函数
        /// </summary>
        public WindowOR()
        {

        }

        /// <summary>
        /// 评价器地址
        /// </summary>
        public string pjqAddress { get; set; }

        /// <summary>
        /// 呼叫器地址
        /// </summary>
        public string fjqAddress { get; set; }

        /// <summary>
        /// 条屏地址
        /// </summary>
        public string tpAddress { get; set; }

        public int? RowNumber { get; set; }
        public int? ColNumber { get; set; }

        /// <summary>
        /// Window构造函数
        /// </summary>
        public WindowOR(DataRow row)
        {
            // 
            _Id = row["Id"].ToString().Trim();
            // 窗口名称
            _Name = row["Name"].ToString().Trim();
            // 声音设备
            if (row["SoundDev"] != DBNull.Value)
                _Sounddev = Convert.ToInt32(row["SoundDev"]);
            // 描述
            _Description = row["Description"].ToString().Trim();
            // 机构
            _Orgbh = row["OrgBH"].ToString().Trim();
            // 周一柜台角色
            _Role = row["Role"].ToString().Trim();
            // 周二柜台角色
            _Jca2 = row["JCA2"].ToString().Trim();
            // 周三柜台角色
            _Jca3 = row["JCA3"].ToString().Trim();
            // 周四柜台角色
            _Jca4 = row["JCA4"].ToString().Trim();
            // 周五柜台角色
            _Jca5 = row["JCA5"].ToString().Trim();
            // 周六柜台角色
            _Jca6 = row["JCA6"].ToString().Trim();
            // 周日柜台角色
            _Jca7 = row["JCA7"].ToString().Trim();

            pjqAddress = row["pjqAddress"].ToString().Trim();
            fjqAddress = row["fjqAddress"].ToString().Trim();
            tpAddress = row["tpAddress"].ToString().Trim();

            if (row["rowNumber"].ToString() != "")
            {
                RowNumber = Convert.ToInt32(row["rowNumber"].ToString());
            }

            if (row["ColNumber"].ToString() != "")
            {
                ColNumber = Convert.ToInt32(row["ColNumber"].ToString());
            }
        }
    }
}

