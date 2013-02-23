using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using QM.Client.DA.MySql;
using QM.Client.Entity;
using System.Collections;
using System.Configuration;

namespace QM.Client.WebService.Control
{
    /// <summary>
    /// 排队主类，包含取号数据。列表数据
    /// 放在一个类，因为，webService 等待时间长一点(应用程序池设置20分钟)，数据就会被清掉。
    /// </summary>
    public class QueueMian
    {
        /*
每种业务类型一个队列，取号时往对应的队列里面插入一个元素，
元素结构包含：是否VIP、取号时间、换算后排队时间、转移窗口号、延后人数、延后时间。
其中，转移窗口号只有按下转移后才使用，延后人数在按下延后以及后面的呼叫后更新；数据结构采用hash实现，关键字是业务类型ID，值是队列，队列里面是元素。延后人数和延后时间作为延后策略的可选项，目前先实现延后时间，预留延后人数的逻辑与接口，实现时可以快速实现；
         */

        #region 属性
        /// <summary>
        /// 网点业务队列
        /// </summary>
        public List<BussinessQueueOR> QhQueues { get; set; }

        /// <summary>
        /// 网点机构号
        /// </summary>
        public string BankNo { get; set; }
        #endregion


 
        BussinessMySqlDA _busDA = new BussinessMySqlDA();//业务DA
        QueueInfoDA _QueueDA=new QueueInfoDA();//取号DA

        #region 初使化
        /// <summary>
        /// 初使化、
        /// </summary>
        public QueueMian()
        {
            InitBankNo();

            List<BussinessOR> ListBuss=new List<BussinessOR>();//所有业务
           
            //查询 所有的业务队列
            ListBuss = _busDA.selectAllBussiness();
            
            //根据队列，取出已取号的排队信息。
            foreach (BussinessOR obj in ListBuss)
            {
                BussinessQueueOR bussQue = new BussinessQueueOR();
                bussQue.ID = obj.Id;
                bussQue.Name = obj.Name;
                bussQue.BussQueues = _QueueDA.selectBussinessQueues(obj.Id);//获取此队列未办结的取号记录
            }
        }

        /// <summary>
        /// 从配置文件获取，网点编号OrgNo
        /// </summary>
        private void InitBankNo()
        {
            BankNo = ConfigurationManager.AppSettings["BankNo"];
        }
        #endregion

        #region 公用函数
        /// <summary>
        /// 根据业务队列ID，获取内存中的 获取业务队列
        /// </summary>
        /// <param name="bussinessID"></param>
        /// <returns></returns>
        private BussinessQueueOR GetBussiness(string bussinessID)
        {
            foreach (BussinessQueueOR obj in QhQueues)
            {

                if (obj.ID == bussinessID)
                    return obj;
            }
            return null;
        }
        #endregion

        #region 取号
        /// <summary>
        /// 取号，差返回票号
        /// </summary>
        /// <param name="bussinessID"></param>
        /// <param name="mCardno"></param>
        /// <returns></returns>
        public string QH(string bussinessID, string mCardno)
        {
            BussinessQueueOR _CurentBuss=GetBussiness(bussinessID);
            if (_CurentBuss == null)
            {
                throw new Exception("获取业务队列失败！，无法取号。");
            }

            string _BillNo = GetBillNo();

            int mWaitpeoplebusssiness = 0;
            int mWaitpeoplebank = 0;
            //int mCustemclass = 0;
            GetWaitPeople(bussinessID, out  mWaitpeoplebusssiness, out mWaitpeoplebank);

            QueueInfoOR _qhOR = new QueueInfoOR(BankNo, _BillNo, bussinessID, mCardno
                , mWaitpeoplebusssiness, mWaitpeoplebank);//初使化取号
            _QueueDA.QH(_qhOR);//将取号插入到数据库

            //插入到当前队列
            _CurentBuss.BussQueues.Add(_qhOR);
            return _BillNo;
        }
        
        
        /// <summary>
        /// 获取排队人数
        /// </summary>
        /// <param name="mBusssinessID"></param>
        /// <param name="mWaitpeopleBussiness"></param>
        /// <param name="mWaitBank"></param>
        private void GetWaitPeople(string mBusssinessID,out int mWaitpeopleBussiness,out int mWaitBank)
        {
            mWaitpeopleBussiness = 0;
            mWaitBank = 0;
            bool isAddBussiness = false;//是否 业务队列计数
            foreach (BussinessQueueOR obj in QhQueues)
            {
                if (obj.ID == mBusssinessID)
                {
                    isAddBussiness = true;
                }
                foreach (QueueInfoOR _qhOr in obj.BussQueues)//计算排除人数
                {
                    if (_qhOr.Status == 0)
                    {
                        mWaitBank++;
                        if (isAddBussiness)//当于队列
                            mWaitpeopleBussiness++;
                    }
                }
                isAddBussiness = false;
            }
        }

        /// <summary>
        /// 获取票号
        /// </summary>
        /// <returns></returns>
        private string GetBillNo()
        {
           int QueNumber= _QueueDA.GetQueueNumber();
           int nowNumber = QueNumber + 1;
           return nowNumber.ToString().PadLeft(4, '0');
        }
        #endregion

    }
}