using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: ConfigHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 用于项目中配置文件帮助类，任何异常信息不捕获，抛到上层应用处理
    /// DateTime: 2014/5/19 10:58:24
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件值
        /// </summary>
        /// <param name="key">配置文件key</param>
        /// <returns>返回字符串值</returns>
        public static string GetValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取配置文件Int值
        /// </summary>
        /// <param name="key">配置文件key</param>
        /// <returns>返回Int类型</returns>
        public static int GetValueOfInt(string key)
        {
            return Convert.ToInt32(GetValue(key));
        }

        /// <summary>
        /// 获取配置文件double值
        /// </summary>
        /// <param name="key">配置文件key</param>
        /// <returns>返回double类型</returns>
        public static double GetValueOfDouble(string key)
        {
            return Convert.ToDouble(GetValue(key));
        }

        /// <summary>
        /// 获取配置的连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
