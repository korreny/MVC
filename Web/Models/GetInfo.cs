using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetDBInfo.Models
{
    //存储表信息
    public class GetInfo
    {
        private string tableName;
        private object field;

        public string TableName
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
            }
        }

        public object Field
        {
            get
            {
                return field;
            }

            set
            {
                field = value;
            }
        }
        // private object type;
    }
    //存储表的单个字段信息
    public class Fieid
    {
        private string fieidname;//字段名字
        private string fieidtype;//字段类型
        private string fieidmean;//字段含义

        public string Fieidname
        {
            get
            {
                return fieidname;
            }

            set
            {
                fieidname = value;
            }
        }

        public string Fieidtype
        {
            get
            {
                return fieidtype;
            }

            set
            {
                fieidtype = value;
            }
        }

        public string Fieidmean
        {
            get
            {
                return fieidmean;
            }

            set
            {
                fieidmean = value;
            }
        }
    }
}