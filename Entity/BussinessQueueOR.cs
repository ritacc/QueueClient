using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 网点业务列名 (业务、此业务的取号记录)
    /// </summary>
    public class BussinessQueueOR : BussinessOR
    {
        /// <summary>
        /// 队列 取号数据
        /// </summary>
        public List<QueueInfoOR> BussQueues { get; set; }
        /// <summary>
        /// 排除人数
        /// </summary>
        public int QueueNumber { get; set; }

       

        public BussinessQueueOR()
        {

        }

        public void Init(BussinessOR obj)
        {
            // 
            this.Id = obj.Id;
            // 业务名称
            this.Name = obj.Name;
            // 英文的业务名称，用于界面显示（可选）
            this.Englishname = obj.Englishname;
            // 业务种类，相当于业务名称的缩写，比如业务名称为“存取款和缴费”，则业务种类为“M1”
            this.Typename = obj.Typename;
            // 等候时间1
            this.Waittime1 = obj.Waittime1;
            // 优先时间1 。“等候时间1”和“优先时间1”指客户等待时间1大于XX秒时，排队优先时间1等于YY秒
            this.Priortime1 = obj.Priortime1;
            // 等候时间2
            this.Waittime2 = obj.Waittime2;
            // 优先时间2。同理，等候时间2需大于等候时间1
            this.Priortime2 = obj.Priortime2;
            // 等候时间3
            this.Waittime3 = obj.Waittime3;
            // 优先时间3。同理，等候时间3需大于等候时间2
            this.Priortime3 = obj.Priortime3;
            // 取号方式。1是刷卡取号----此队列必须刷卡取号。2是直接取号----直接取号无需刷卡。3是刷卡直接取号----可以直接取号也可刷卡取号
            this.Ticketmethod = obj.Ticketmethod;

            // 周一是否办理的标记，1表示办理，0表示不能办理
            this.Mondayflag = obj.Mondayflag;

            // 周一工作时间，不能超过3个时间段，各时间段以分号隔开。如08301200;13001400;15001800;表示从8:30到12:00，然后13:00到14:00,然后15:00到18:00.只有1个时间段时为08301200;;;
            this.Mondaytime = obj.Mondaytime;

            // 周二办理标记
            this.Tuesdayflag = obj.Tuesdayflag;

            // 周二工作时间
            this.Tuesdaytime = obj.Tuesdaytime;
            // 周三办理标记
            this.Wednesdayflag = obj.Wednesdayflag;

            // 周三工作时间
            this.Wednesdaytime = obj.Wednesdaytime;
            // 周l四办理标记
            this.Thurdayflag = obj.Thurdayflag;

            // 周四工作时间
            this.Thurdaytime = obj.Thurdaytime;

            // 周五办理标记
            this.Fridayflag = obj.Fridayflag;

            // 周五工作时间
            this.Fridaytime = obj.Fridaytime;
            // 周六办理标记
            this.Saturdayflag = obj.Saturdayflag;

            // 周六办理标记
            this.Saturdaytime = obj.Saturdaytime;

            // 周日办理标记
            this.Sundayflag = obj.Sundayflag;

            // 周日工作时间
            this.Sundaytime = obj.Sundaytime;
            // 描述
            this.Description = obj.Description;
            // 机构编号
            this.Orgbh = obj.Orgbh;
        }

        public void InitNumber()
        {
            if (BussQueues == null)
            {
                this.QueueNumber = 0;
                return;
            }
            int qhNumber = 0;
            foreach (var v in BussQueues)
            {
                if (v.Status == 0)
                    qhNumber++;
            }
            this.QueueNumber = qhNumber;
        }

        //public BussinessQueueOR(DataRow dr)
        //{
        //    ID = dr["id"].ToString();
        //    Name = dr["name"].ToString();
        //}
    }
}
