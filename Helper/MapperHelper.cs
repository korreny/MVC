using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Globalization;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: MapperHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 16:07:35
    /// </summary>
    public class MapperHelper
    {
        #region 对外方法

        /// <summary>
        /// 转化为object类型
        /// </summary>
        /// <param name="adaptedRow">数据行</param>
        /// <param name="entityType">类型type</param>
        /// <returns>object</returns>
        public static object ToEntity(DataRow adaptedRow, Type entityType)
        {
            if (entityType == null || adaptedRow == null)
            {
                return null;
            }

            object entity = Activator.CreateInstance(entityType);
            CopyToEntity(entity, adaptedRow);

            return entity;
        }

        /// <summary>
        /// 转换为对象List
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static List<T> ToEntityList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    T item = new T();
                    list.Add(ToEntity<T>(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 转化为对应实体类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="adaptedRow">数据行</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static T ToEntity<T>(DataRow adaptedRow) where T : new()
        {
            T item = new T();
            if (adaptedRow == null)
            {
                return item;
            }

            item = Activator.CreateInstance<T>();
            CopyToEntity(item, adaptedRow);

            return item;
        }

        /// <summary>
        /// 将数据行中的值copy到实体的属性上去
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="adaptedRow">数据行</param>
        public static void CopyToEntity(object entity, DataRow adaptedRow)
        {
            if (entity == null || adaptedRow == null)
            {
                return;
            }
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!CanSetPropertyValue(propertyInfo, adaptedRow))
                {
                    continue;
                }

                try
                {
                    if (adaptedRow[propertyInfo.Name] is DBNull)
                    {
                        propertyInfo.SetValue(entity, null, null);
                        continue;
                    }
                    SetPropertyValue(entity, adaptedRow, propertyInfo);
                }
                finally
                {

                }
            }
        }

        #endregion

        #region 私有辅助

        /// <summary>
        /// 判断是否可以设置
        /// </summary>
        /// <param name="propertyInfo">实体对象</param>
        /// <param name="adaptedRow">数据行</param>
        /// <returns>是否可以设置</returns>
        private static bool CanSetPropertyValue(PropertyInfo propertyInfo, DataRow adaptedRow)
        {
            if (!propertyInfo.CanWrite)
            {
                return false;
            }

            if (!adaptedRow.Table.Columns.Contains(propertyInfo.Name))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置实体属性值
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="adaptedRow">数据行</param>
        /// <param name="propertyInfo">属性</param>
        private static void SetPropertyValue(object entity, DataRow adaptedRow, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(DateTime?) ||
                propertyInfo.PropertyType == typeof(DateTime))
            {
                DateTime date = DateTime.MaxValue;
                DateTime.TryParse(adaptedRow[propertyInfo.Name].ToString(),
                    CultureInfo.CurrentCulture, DateTimeStyles.None, out date);

                propertyInfo.SetValue(entity, date, null);
            }
            else
            {
                propertyInfo.SetValue(entity, adaptedRow[propertyInfo.Name], null);
            }
        }

        #endregion
    }
}
