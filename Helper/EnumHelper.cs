using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Data;

namespace com.iflysse.helper
{

    [global::System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class EnumAttribute : Attribute
    {
        // See the attribute guidelines at 

        readonly string enName;

        readonly string name;

        // This is a positional argument
        public EnumAttribute(string enName, string name)
        {
            this.name = name;
            this.enName = enName;
        }

        public string Name
        {
            get { return name; }
            private set { }
        }

        public string EnName { get { return enName; } private set { } }

        // This is a named argument
    }

    public enum Language
    {
        CN = 2052, EN = 1033
    }

    /// <summary>
    /// FileName: EnumHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 15:00:03
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 根据枚举值获取其上的文字Attr
        /// </summary>
        /// <param name="obj">传入某枚举，如 InstanceState.Approving</param>
        /// <returns></returns>
        public static string GetName(object obj)
        {
            CultureInfo cul = Thread.CurrentThread.CurrentCulture;
            return GetName(obj, cul.LCID);
        }

        public static string GetName(object obj, Language lan)
        {
            return GetName(obj, (int)lan);
        }

        public static string GetName(Type enumType, string value)
        {
            return GetName(Enum.Parse(enumType, value));
        }

        public static string GetName(Type enumType, string value, Language lan)
        {
            return GetName(Enum.Parse(enumType, value), (int)lan);
        }

        public static Dictionary<string, int> GetDataSource(Type enumType)
        {
            if (enumType.IsEnum)
            {
                Dictionary<string, int> list = new Dictionary<string, int>();
                Array vals = Enum.GetValues(enumType);
                foreach (object val in vals)
                {

                    list.Add(GetName(enumType, val.ToString()), Convert.ToInt32(val));
                }
                return list;
            }
            throw new ArgumentException("argument should enum type!");
        }

        static string GetName(object obj, int lcid)
        {
            Type typeDescription = typeof(EnumAttribute);
            Type enumType = obj.GetType();
            if (enumType.IsEnum)
            {
                System.Reflection.FieldInfo fieldInfo = enumType.GetField(obj.ToString());
                object[] attr = fieldInfo.GetCustomAttributes(typeDescription, false);
                if (attr.Length > 0)
                {
                    EnumAttribute attrEnum = attr[0] as EnumAttribute;
                    return GetNameByCulture(attrEnum, lcid);
                }
            }
            return obj.ToString();
        }

        static string GetNameByCulture(EnumAttribute attr, int lcid)
        {
            bool zh = lcid == 2052;
            if (zh)
            {
                return attr.Name;
            }
            else
            {
                return attr.EnName;
            }
        }

        /// <summary>
        /// 根据Field获取Description说明的值
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string GetDescription(FieldInfo fi)
        {
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return arrDesc[0].Description;
        }
    }
}
