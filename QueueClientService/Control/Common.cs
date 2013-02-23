﻿using System;
using System.Collections.Generic;
using System.Web;

namespace QM.Client.WebService.Control
{
    public class Common
    {
        /// <summary>
        /// 根据当前网点的机构编号：获取查询条件(网点的当前级、上一级、到最上层一级)
        /// </summary>
        /// <param name="Filds"></param>
        /// <param name="strOrgbh"></param>
        /// <returns></returns>
        public static  string GetOrgbhWhere(string Filds,string strOrgbh)
        {
            string dataArea = strOrgbh;
            if (string.IsNullOrEmpty(dataArea))
                throw new Exception("获取用户数据范围失败！");
            if (dataArea.Length == 6)
                return string.Format("{0}='{1}'", Filds, dataArea);
            string strWhere = string.Format(" {0}='{1}'", Filds, dataArea);
            int ForLen = dataArea.Length / 6;
            for (int i = 1; i < ForLen; i++)
            {
                int RemoveLen = dataArea.Length - i * 6;
                strWhere = string.Format(" {0} or {1}='{2}'", strWhere, Filds, dataArea.Substring(0, RemoveLen));
            }
            return string.Format("({0})", strWhere);
        }
    }
}