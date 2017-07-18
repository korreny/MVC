using System;
using System.Collections.Generic;
using System.Text;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: StringHelper.cs
    /// CLRVersion: 
    /// Author: zysu
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 17:15:29
    /// </summary>
    public class StringHelper
    {    
        #region 比较两个集合，找到在compareList但不在baseList的对象

        /// <summary>
        /// 比较两个集合，找到在compareList但不在baseList的对象
        /// </summary>
        /// <param name="baseList"></param>
        /// <param name="compareList"></param>
        /// <returns></returns>
        public static List<string> Compare(List<string> baseList, List<string> compareList)
        {
            List<string> list = new List<string>();

            if (compareList != null && compareList.Count > 0)
            {
                foreach (string str in compareList)
                {
                    if (!baseList.Contains(str))
                    {
                        list.Add(str);
                    }
                }
            }
            return list;
        }

        #endregion

        #region 将字符串集合转换为字符串，以,分隔

        /// <summary>
        /// 将字符串集合转换为字符串，以,分隔
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2String(List<string> list)
        {
            string String = string.Empty;
            if (list != null && list.Count > 0)
            {
                int count = 0;
                foreach (string str in list)
                {
                    count++;
                    String += str;
                    if (count < list.Count)
                    {
                        String += ",";
                    }
                }
            }

            return String;
        }

        #endregion
    }
}
