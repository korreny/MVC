using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDBInfo.Model
{
    public class DBinfo
    {
        private int _DBtype;//1代表sqlserver数据库,2代表MySQL数据库
        private string _DBip;
        private string _Uid;
        private string _Pwd;
        private string _DBname;

        public DBinfo(int dbtype, string dbip, string uid, string pwd, string dbname)
        {
            _DBtype = dbtype;
            _DBip = dbip;
            _Uid = uid;
            _Pwd = pwd;
            _DBname = dbname;

        }
        public int DBtype
        {
            get
            {
                return _DBtype;
            }

            set
            {
                _DBtype = value;
            }
        }

        public string DBip
        {
            get
            {
                return _DBip;
            }

            set
            {
                _DBip = value;
            }
        }

        public string Uid
        {
            get
            {
                return _Uid;
            }

            set
            {
                _Uid = value;
            }
        }

        public string Pwd
        {
            get
            {
                return _Pwd;
            }

            set
            {
                _Pwd = value;
            }
        }

        public string DBname
        {
            get
            {
                return _DBname;
            }

            set
            {
                _DBname = value;
            }
        }
    }
}
