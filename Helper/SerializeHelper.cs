#region 说明
/* ===============================
* 
* Author：dlli5 Time：2014/8/25 14:48:00 
* File name：SerializeHelper 
* Version：V1.0.1
* Company: Iflysse 
* ================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Com.Iflysse.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializeHelper
    {
        private static string _sysEncoding = "UTF-8";

        /// <summary>
        /// 将对象转化成Json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns>Json</returns>
        public static string Serialize<T>(this T t)
        {
            // 将对象转化成Json字符串    
            string output = string.Empty;
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                ds.WriteObject(ms, t);
                output = Encoding.GetEncoding(_sysEncoding).GetString(ms.ToArray());
            }

            return output;
        }

        /// <summary>
        /// 将Json字符串转换成指定类型的对象
        /// </summary>
        /// <param name="t">对象类型</param>
        /// <returns></returns>
        public static T Deserialize<T>(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Activator.CreateInstance<T>();
            }

            // 将Json字符串转化成对象    
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.GetEncoding(_sysEncoding).GetBytes(str)))
            {
                T t = (T)ds.ReadObject(ms);

                return t;
            }
        }
    }
}
