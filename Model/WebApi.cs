using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetDBInfo.Model
{
    public class WebApi
    {
        private int code;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        private String msg;

        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
