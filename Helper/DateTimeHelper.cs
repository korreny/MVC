using System;
using System.Collections.Generic;
using System.Text;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: DateTimeHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 11:33:25
    /// </summary>
    public class DateTimeHelper
    {
        #region 常量

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public const string YYYY_MM_DD = "yyyy-MM-dd";

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string YYYY_MM_DD_HH_mm_SS = "yyyy-MM-dd HH:mm:ss";

        #endregion

        /// <summary>
        /// 将时间类型转换为字符串格式
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="formatStr">时间字符串格式</param>
        /// <returns></returns>
        public static string ToDateStr(DateTime dt, string formatStr)
        {
            if (dt == DateTime.MinValue)
            {
                return "";
            }
            return dt.ToString(formatStr);
        }

        /// <summary>
        /// 获取当前时间所在的周一和周日时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns>周一开始时间和周末结束时间</returns>
        public static DateTime[] GetMondayAndSundayOfTime(DateTime dt)
        {
            //获取改时间是本周的第几天
            int thedayoftheweek = Convert.ToInt32(dt.DayOfWeek.ToString("d"));
            //本周周一
            DateTime startWeek = dt.AddDays(1 - (thedayoftheweek == 0 ? 7 : thedayoftheweek));
            return new DateTime[] { startWeek, startWeek.AddDays(6) };
        }

        /// <summary>
        /// 获取时间所在当天的开始和结束时间
        /// 获取时间所在当天的开始和结束时间(注：在这里当天的结束时间是在明天的开始的基础上加上-1的Tick值)
        /// 如 2014-05-12 12:12 012
        /// 得到2014-05-12 00:00:00 和 2014-05-12 59:59:59:999
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] GetBeginAndEndOfDay(DateTime dt)
        {
            string dateStr = ToDateStr(dt, DateTimeHelper.YYYY_MM_DD);
            DateTime beginTime = DateTime.Parse(dt.ToString("yyyy-MM-dd"));
            DateTime endTime = beginTime.AddDays(1).AddTicks(-1);
            return new DateTime[] { beginTime, endTime };
        }

        /// <summary>
        /// 获取时间所在月的开始和结束时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] GetBeginAndEndOfMonth(DateTime dt)
        {
            DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
            return new DateTime[] { startMonth, endMonth };
        }

        /// <summary>
        /// 获取时间所在季度的开始和结束时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] GetBeginAndEndOfQuarter(DateTime dt)
        {
            //本季度初
            DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);
            //本季度末
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);
            return new DateTime[] { startQuarter, endQuarter };
        }

        /// <summary>
        /// 获取本年年初和年末
        /// 此方法其实完全没必要不过放在这里吧作为公共部分
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] GetBeginAndEndOfYear(DateTime dt)
        {
            DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
            DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末
            return new DateTime[] { startYear, endYear };
        }

        /// <summary>
        /// 获取某一年某一月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public static int GetMonthDays(int year, int month)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }

        /// <summary>
        /// 获取两个时间段的相隔天数
        /// </summary>
        /// <param name="begin">开始时间(小)</param>
        /// <param name="end">结束时间(大)</param>
        /// <returns></returns>
        public static int GetIntervalDaysOfTwoDateTime(DateTime begin, DateTime end)
        {
            //如果开始时间比结束时间大,交换时间
            if (begin.CompareTo(end) > 0)
            {
                DateTime temp = begin;
                begin = end;
                end = temp;
            }
            int days = 0;
            //计算年的相差天数
            for (int i = begin.Year; i < end.Year; i++)
            {
                days += (DateTime.IsLeapYear(i) == true ? 366 : 365);
            }
            //计算月的相差天数
            days += end.DayOfYear - begin.DayOfYear;

            return days;
        }
    }
}
