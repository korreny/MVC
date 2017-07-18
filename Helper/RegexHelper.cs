using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: RegexHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 正则帮助类
    /// DateTime: 2014/5/19 14:01:45
    /// </summary>
    public class RegexHelper
    {
        #region 常量

        /// <summary>
        /// 清除包含'字符串
        /// </summary>
        public const string CLEAN_STRING = @"[']";

        /// <summary>
        /// 验证字符串是否为字符begin-end之间
        /// </summary>
        public const string IS_VALID_BYTE = @"^[A-Za-z0-9]{#0#,#1#}$";

        /// <summary>
        /// 验证字符串是否为年月日
        /// </summary>
        public const string IS_VALID_DATE = @"^2\d{3}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|[1-2]\d|3[0-1])(?:0?[1-9]|1\d|2[0-3]):(?:0?[1-9]|[1-5]\d):(?:0?[1-9]|[1-5]\d)$";

        /// <summary>
        /// 验证字符串是否为小数
        /// </summary>
        public const string IS_VALID_DECIMAL = @"[0].\d{1,2}|[1]";

        /// <summary>
        /// 验证字符串是否为EMAIL
        /// </summary>
        public const string IS_VALID_EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        /// <summary>
        /// 验证字符串是否为IP
        /// </summary>
        public const string IS_VALID_IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>
        /// 验证字符串是否为后缀名
        /// </summary>
        public const string IS_VALID_POSTFIX = @"\.(?i:{0})$";

        /// <summary>
        /// 验证字符串是否为电话号码
        /// </summary>
        public const string IS_VALID_TEL = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";

        /// <summary>
        /// 手机格式
        /// </summary>
        public const string IS_Phone = @"^1[3|4|5|8][0-9]\d{4,8}$";

        /// <summary>
        /// 验证字符串是否为URL
        /// </summary>
        public const string IS_VALID_URL = @"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";

        /// <summary>
        /// 特殊字符
        /// </summary>
        public const string IS_TESHU = "[~!@#$%_^&*()=+[\\]{}''\";:/?.,><`|！·￥…—（）\\-、；：。，》《]";

        /// <summary>
        /// 影响页面样式的特殊字符
        /// </summary>
        public const string IS_TESHUFORHTML = @"^[^'&<>[\]{}]+$";

        /// <summary>
        /// 影响页面正则表达式
        /// </summary>
        public const string IS_TESHUFORHTMLS = @"^[^'&<>\u0022[\]]+$";

        #endregion

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <returns>是否验证通过</returns>
        public static bool CheckInput(string input, string regex)
        {
            return Regex.IsMatch(input, regex);
        }

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <returns>替换后字符串</returns>
        public static string ReplaceInput(string input, string regex)
        {
            return Regex.Replace(input, regex, string.Empty);
        }

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="replace">替换字符串</param>
        /// <returns>替换后字符串</returns>
        public static string ReplaceInput(string input, string regex, string replace)
        {
            return Regex.Replace(input, regex, replace);
        }

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="begin">开始数字</param>
        /// <param name="end">结尾数字</param>
        /// <returns>是否验证通过</returns>
        public static bool ValidByte(string input, string regex, int begin, int end)
        {
            bool ret = false;
            if (!string.IsNullOrEmpty(regex))
            {
                string rep = regex.Replace("#0#", begin.ToString(CultureInfo.InvariantCulture));
                rep = rep.Replace("#1#", end.ToString(CultureInfo.InvariantCulture));
                ret = CheckInput(input, rep);
            }
            return ret;
        }

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="fix">后缀名</param>
        /// <returns>是否验证通过</returns>
        public static bool ValidPostfix(string input, string regex, string fix)
        {
            string ret = string.Format(CultureInfo.InvariantCulture, regex, fix);
            return CheckInput(input, ret);
        }

        /// <summary>
        /// 验证身份证函数
        /// </summary>
        /// <param name="SFZ">身份证号码</param>
        /// <returns>是否验证通过</returns>
        public static bool IsIdentity(string SFZ)
        {
            string date = "", Ai = "";
            string verify = "10x98765432";
            int[] Wi = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            string[] area = { "", "", "", "", "", "", "", "", "", "", "", "北京", "天津", "河北", "山西", "内蒙古", "", "", "", "", "", "辽宁", "吉林", "黑龙江", "", "", "", "", "", "", "", "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", "", "", "", "河南", "湖北", "湖南", "广东", "广西", "海南", "", "", "", "重庆", "四川", "贵州", "云南", "西藏", "", "", "", "", "", "", "陕西", "甘肃", "青海", "宁夏", "新疆", "", "", "", "", "", "台湾", "", "", "", "", "", "", "", "", "", "香港", "澳门", "", "", "", "", "", "", "", "", "国外" };
            string[] re = Regex.Split(SFZ, @"^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$", RegexOptions.IgnoreCase);
            if (re.Length != 9) return false;
            int ProvId = int.Parse(re[1]);
            if (ProvId >= area.Length || area[ProvId] == "") return false;
            if (re[2].Length == 12)
            {
                Ai = SFZ.Substring(0, 17);
                date = re[4] + "-" + re[5] + "-" + re[6];
            }
            else
            {
                Ai = SFZ.Substring(0, 6) + "19" + SFZ.Substring(6);
                date = "19" + re[4] + "-" + re[5] + "-" + re[6];
            }
            try
            {
                DateTime.Parse(date);
            }
            catch
            {
                return false;
            }
            int sum = 0;
            for (int i = 0; i <= 16; i++)
            {
                sum += int.Parse(Ai.Substring(i, 1)) * Wi[i];
            }
            Ai += verify.Substring(sum % 11, 1);
            return (SFZ.Length == 15 || SFZ.Length == 18 && SFZ.ToLower() == Ai);
        }
    }
}
