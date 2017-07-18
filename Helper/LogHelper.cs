using System;
using System.Collections.Generic;
using System.Text;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: LogHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/6/5 9:10:56
    /// </summary>
    public class LogHelper
    {
        // lock对象
        private static object lockLog = new object();

        private static log4net.ILog _logError = null;

        /// <summary>
        /// 记录异常信息
        /// </summary>
        public static log4net.ILog LogError
        {
            get
            {
                if (_logError == null)
                {
                    lock (lockLog)
                    {
                        _logError = log4net.LogManager.GetLogger("loggerError");
                    }
                }
                return _logError;
            }
        }

        private static log4net.ILog _logInfo = null;

        /// <summary>
        /// 记录操作信息
        /// </summary>
        public static log4net.ILog LogInfo
        {
            get
            {
                if (_logInfo == null)
                {
                    lock (lockLog)
                    {
                        _logInfo = log4net.LogManager.GetLogger("loggerInfo");
                    }
                }
                return _logInfo;
            }
        }

        private static log4net.ILog _logDebug = null;

        /// <summary>
        /// 记录调试信息
        /// </summary>
        public static log4net.ILog LogDebug
        {
            get
            {
                if (_logDebug == null)
                {
                    lock (lockLog)
                    {
                        _logDebug = log4net.LogManager.GetLogger("loggerDebug");
                    }
                }
                return _logDebug;
            }
        }
    }
}
