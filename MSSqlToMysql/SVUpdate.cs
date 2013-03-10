using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Threading;

namespace QM.Client.UpdateDB
{
    partial class SVUpdate : ServiceBase
    {
        public SVUpdate()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 取号数据 上传同步 时间长度(秒)
        /// </summary>
        public int QueueUpTimeLen { get; set; }
        /// <summary>
        /// 参数同步时间：(-1:启动时更新。0-23：小时为指定时间(小时)，更新一次。)-
        /// </summary>
        public int ParaDownTime { get; set; }
        #endregion
        Thread ParaUpdateThread;
        Thread QueueinfoUpdateThread;
        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            WriteLog.writLog("0000", "OnStart");
            if (InitAppSett())
            {
                //参数同步                
                if (ParaDownTime < -1 || ParaDownTime > 23)
                {
                    WriteLog.writLog("1002", "参数配置");
                }
                else if (ParaDownTime == -1)
                {
                    UpdataParaControl();
                }
                else
                {
                    ParaUpdateThread = new Thread(UpdataParaThread);
                    ParaUpdateThread.Start();

                }

                //上传取号数据

                QueueinfoUpdateThread = new Thread(QueueUpdateControl);
                QueueinfoUpdateThread.Start();
                //trUpQueue.Interval = QueueUpTimeLen * 1000;
                //trUpQueue.Start();// = true;
                WriteLog.writLog("0000", string.Format("OnStartEnd :QueueUpTimeLen={0};ParaDownTime={1}", QueueUpTimeLen, ParaDownTime));
            }
            else
            {
                WriteLog.writLog("0000", "OnStart InitAppSett 出错。");
            }
            
        }
        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            if (ParaUpdateThread != null)
            {
                ParaUpdateThread.Abort();
            }

            if (QueueinfoUpdateThread != null)
                QueueinfoUpdateThread.Abort();

            WriteLog.writLog("0000", "服务已停止");
        }
        /// <summary>
        /// 从配置文件读参数
        /// </summary>
        /// <returns></returns>
        private bool InitAppSett()
        {
            try
            {
                QueueUpTimeLen = Convert.ToInt32(ConfigurationManager.AppSettings["QueueUpTimeLen"]);
                ParaDownTime = Convert.ToInt32(ConfigurationManager.AppSettings["ParaDownTime"]);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog.writLog("1001", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 指定时间更新参数
        /// </summary>
        private void UpdataParaThread()
        {
            do
            {
                WriteLog.writLog("0000", "UpdataParaThread。");
                if (DateTime.Now.Hour == ParaDownTime)
                {
                    UpdataParaControl();
                }
                Thread.Sleep(60 * 60 * 1000);//一小时
            } while (true);
        }

        /// <summary>
        /// 更新取号数据
        /// </summary>
        private void QueueUpdateControl()
        {
            if (QueueUpTimeLen < 30)//最小时间30
                QueueUpTimeLen = 30;
            do
            {
                WriteLog.writLog("0000", "QueueUpdateControl。");
                QueueinfoUpdate();
                Thread.Sleep(QueueUpTimeLen * 1000);
            } while (true);
        }

        
        protected void UpdataParaControl()
        {
            WriteLog.writLog("0000", "UpdataParaControl");
            ParaUpdateControl _BussCon = new ParaUpdateControl();
            if (_BussCon.Init())
            {
                _BussCon.UpdateBussiness();
                _BussCon.UpdateBank();
                //只更新自己网点数据
                _BussCon.UpdateEmployee();
                _BussCon.UpdateSysPara();
                _BussCon.UpdatePageWin();
                _BussCon.UpdateQhandy();
                _BussCon.UpdateShutdownTime();
                _BussCon.UpdateWindow();
                _BussCon.UpdateNearbyInfo();

                //继承上级数据
                _BussCon.UpdateBussinessRole();
                _BussCon.UpdateBussinessRoleON();
                _BussCon.UpdateEmployType();
                _BussCon.UpdateSmsPeople();
                _BussCon.UpdateVIPCardKey();
                _BussCon.UpdateVipCardType();
            }
        }

        /// <summary>
        /// 同步(上传取号数据)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueueinfoUpdate()
        {
            WriteLog.writLog("0000", "QueueinfoUpdate:开始更新取号数据。");
            QueueinfoControl QC = new QueueinfoControl();
            QC.UpQueueData();
        }
    }
}
