using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class SysParaMySqlDA : DALBase
    {
        public SysParamConfigOR SelectConfigORByWdbh()
        {

            string sql = "select * from t_SysPara ";
//            if (_wdbh.Length > 6)
//            {
//                string topWdbh = _wdbh.Substring(0, 6);

//                sql += string.Format(@" or (orgbh='{0}' and (KeyStr='vipcardinfo' or KeyStr='othercardinfo' 
//or KeyStr='invalidcardinfo'  or KeyStr='validcardcode'))", topWdbh);
//            }


            DataTable dt = dbMySql.ExecuteQuery(sql);
            SysParamConfigOR _obj = new SysParamConfigOR();
            foreach (DataRow dr in dt.Rows)
            {
                string ValueStr = dr["ValueStr"].ToString();
                switch (dr["KeyStr"].ToString().ToLower())
                {
                    case "popswiptime":// 提示刷卡界面停留时间
                        _obj.Popswiptime = ValueStr;
                        break;
                    case "contickettime":// 连续取号最短时间间隔等
                        _obj.Contickettime = ValueStr;
                        break;
                    case "cartickettime":// 同一张卡连续取号时间间隔
                        _obj.Cartickettime = ValueStr;
                        break;
                    case "calllimittime":// 呼叫限制
                        _obj.Calllimittime = ValueStr;
                        break;
                    case "curshowtime":// 每个排队曲线图显示时间，为0表示不显示
                        _obj.Curshowtime = ValueStr;
                        break;
                    case "windowinfo":// 窗口屏广告信息
                        _obj.Windowinfo = ValueStr;
                        break;
                    case "mainwindowinfo":// 主显屏广告信息
                        _obj.Mainwindowinfo = ValueStr;
                        break;
                    case "backgroundsound":// 呼叫提示音(1-无;2-提示音1;3-提示音2;4-提示音3)
                        _obj.Backgroundsound = ValueStr;
                        break;
                    case "firstsound":// 第一遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
                        _obj.Firstsound = ValueStr;
                        break;
                    case "secondsound":// 第二遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
                        _obj.Secondsound = ValueStr;
                        break;
                    case "thirdsound":// 第三遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
                        _obj.Thirdsound = ValueStr;
                        break;
                    case "callvolumn": // 语音呼叫音量（范围0-9）
                        _obj.Callvolumn = ValueStr;
                        break;
                    case "backgroundvolumn":// 背景音乐音量（范围0-9）
                        _obj.Backgroundvolumn = ValueStr;
                        break;

                    case "vipcardinfo":// 贵宾服务刷卡取号提示语
                        _obj.Vipcardinfo = ValueStr;
                        break;
                    case "othercardinfo":// 其他业务刷卡取号提示语
                        _obj.Othercardinfo = ValueStr;
                        break;
                    case "invalidcardinfo":// 无效卡提示语
                        _obj.Invalidcardinfo = ValueStr;
                        break;
                    case "validcardcode":// 无效卡提示语
                        _obj.ValidCardCode = ValueStr;
                        break;
                }

            }
            return _obj;
        }

        #region 更新
        public void UpdateSysPara(List<SysParaOR> listsysPara)
        {
            string sql = "truncate table t_SysPara";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (SysParaOR obj in listsysPara)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(SysParaOR sysPara)
        {
            string sql = @"insert into t_SysPara (Id,OrgBH,KeyStr,ValueStr,Description)
values ('@Id','@OrgBH','@KeyStr','@ValueStr','@Description')";
            sql = sql.Replace("@Id", sysPara.Id);	//
            sql = sql.Replace("@OrgBH", sysPara.Orgbh);	//所属机构
            sql = sql.Replace("@KeyStr", sysPara.Keystr);	//关键字
            sql = sql.Replace("@ValueStr", sysPara.Valuestr);	//值
            sql = sql.Replace("@Description", sysPara.Description);	//描述

            return sql;
        }
        #endregion

    }
}

