using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
   public class DeviceType
    {
        /*
 * 
 * INSERT INTO `t_devicetype` VALUES ('1', '呼叫器');
INSERT INTO `t_devicetype` VALUES ('2', '条屏');
INSERT INTO `t_devicetype` VALUES ('3', '评价器');
INSERT INTO `t_devicetype` VALUES ('4', '主屏');
 * */
       public const int DeviceType_FJQ = 1;
        public const int DeviceType_TP = 2;
        public const int DeviceType_PJQ = 3;
        public const int DeviceType_ZP = 4;

        public static string GetTypeName(int mType)
        {
            string result = string.Empty;

            switch (mType)
            {
                case DeviceType_FJQ:
                    result = "呼叫器";
                    break;
                case DeviceType_TP:
                    result = "条屏";
                    break;

                case DeviceType_PJQ:
                    result = "评价器";
                    break;
                case DeviceType_ZP:
                    result = "主屏";
                    break;
            }
            return result;
        }
    }
}
