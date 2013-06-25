using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    public class EmployeeOR
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
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        private string _Employno;
        /// <summary>
        /// 柜员编号
        /// </summary>
        public string Employno
        {
            get { return _Employno; }
            set { _Employno = value; }
        }

        private string _Pwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return _Pwd; }
            set { _Pwd = value; }
        }

        private string _Employtype;
        /// <summary>
        /// 外键，关联到表t_EmployType中
        /// </summary>
        public string Employtype
        {
            get { return _Employtype; }
            set { _Employtype = value; }
        }

        private string _Highrole;
        /// <summary>
        /// 默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示高柜业务角色
        /// </summary>
        public string Highrole
        {
            get { return _Highrole; }
            set { _Highrole = value; }
        }

        private string _Lowrole;
        /// <summary>
        /// 默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示低柜业务角色
        /// </summary>
        public string Lowrole
        {
            get { return _Lowrole; }
            set { _Lowrole = value; }
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
        /// 机构编号
        /// </summary>
        public string Orgbh
        {
            get { return _Orgbh; }
            set { _Orgbh = value; }
        }

        /// <summary>
        /// Employee构造函数
        /// </summary>
        public EmployeeOR()
        {

        }

        /// <summary>
        /// Employee构造函数
        /// </summary>
        public EmployeeOR(DataRow row)
        {
            // 
            _Id = row["Id"].ToString().Trim();
            // 姓名
            _Name = row["Name"].ToString().Trim();
            // 柜员编号
            _Employno = row["EmployNo"].ToString().Trim();
            _Pwd = row["pwd"].ToString().Trim();
            // 外键，关联到表t_EmployType中
            _Employtype = row["EmployType"].ToString().Trim();
            // 默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示高柜业务角色
            _Highrole = row["HighRole"].ToString().Trim();
            // 默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示低柜业务角色
            _Lowrole = row["LowRole"].ToString().Trim();
            // 描述
            _Description = row["Description"].ToString().Trim();
            // 机构编号
            _Orgbh = row["OrgBH"].ToString().Trim();
        }
    }
}
