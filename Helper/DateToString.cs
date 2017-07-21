using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table.Common
{
    public static  class DateToString
    {
        public static string Tostr(DateTime dt)
        {
            string s = "";
            if (dt.ToString().Length>18)
            {
                s += dt.ToString("yyyy/MM/dd");
                s += " ";
                s += dt.ToString("hh:mm:ss");
                return s;
            }else
            {
                return dt.ToString();
            }
        }

    }
}
