using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.iflysse.helper
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class ResultCode
    {
        public const string SUCCESS = "SUCCESS";

        public const string FAIL = "FAIL";
    }

    /// <summary>
    /// Webservice返回结果对象
    /// </summary>
    [Serializable]
    public class JsonResultInfo
    {
        /// <summary>
        /// 结果代码
        /// </summary>
        public string ResultCode { set; get; }

        /// <summary>
        /// 结果描述
        /// </summary>
        public string ResultDesc { set; get; }

        /// <summary>
        /// 结果集
        /// </summary>
        public object ReusltObj { set; get; }

        /// <summary>
        /// 转化为json字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// FileName: JsonHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 16:11:11
    /// </summary>
    public class JsonHelper
    {
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
