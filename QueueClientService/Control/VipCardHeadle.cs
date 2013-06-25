using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QM.Client.Entity;
using QM.Client.DA.MySql;

namespace QM.Client.WebService.Control
{
    public class VipCardHeadle
    {
        /// <summary>
        /// VipCardKey
        /// </summary>
        public List<VIPCardKeyOR> ListVipCardKey { get; set; }

        /// <summary>
        /// Vip卡类型 
        /// </summary>
        public List<VipCardTypeOR> ListVipCardType { get; set; }

        public void Init()
        {
            //Vipcard设置
            VIPCardKeyMySqlDA vipDA = new VIPCardKeyMySqlDA();
            ListVipCardKey = vipDA.selectAllVipCard();

            //Vip类型
            VipCardTypeMySqlDA vipTypeDA = new VipCardTypeMySqlDA();
            ListVipCardType = vipTypeDA.selectAllVipCardType();
        }

        public int GetFirstTime(string mCard)
        {
            foreach (VIPCardKeyOR obj in ListVipCardKey)
            {
                //验证规则
                if (Common.CardViald(mCard, obj.Vipcardkey))
                {
                    return GetCardTypeFirst(obj.Vipcardtype);
                }
            }
            return 0;
        }

        private int GetCardTypeFirst(string cardkeyType)
        {
            foreach (VipCardTypeOR obj in ListVipCardType)
            {
                if (obj.Id == cardkeyType)
                    return obj.Firsttime * 60;
            }
            return 0;
        }
    }
}