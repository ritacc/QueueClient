using System;
using System.Collections.Generic;
using System.Text;

namespace ServerInstall
{
   public class StrCommon
    {
       public static string GetParamValue(ref string strValue, string strKey, string strSpitKey)
       {
           string str = "";
           int length = -1;
           length = strValue.IndexOf(strKey);
           if (length >= 0)
           {
               strValue = strValue.Substring(length + strKey.Length);
               if (strSpitKey == "")
               {
                   str = strValue;
               }
               else
               {
                   length = strValue.IndexOf(strSpitKey);
                   if (length >= 0)
                   {
                       str = strValue.Substring(0, length);
                       strValue = strValue.Substring(length + 1);
                   }
               }
           }
           return str;
       }
    }
}
