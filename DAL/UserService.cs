using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GetDBInfo.Model;
using com.iflysse.helper;
using System.Data;
using Com.Iflysse.Helper;
namespace GetDBInfo.DAL
{
    /// <summary>
    /// FileName: UserService.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: ranli2
    /// Corporation: iosten
    /// Description: user data access class
    /// DateTime: 2017-05-01 09:32:54
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Get user username
        /// </summary>
        /// <param name="User">model.user</param>
        /// <returns></returns>
        public User UserLogin(User User)
        {
            string sql = string.Format("select user_nickname from user where user_account='{0}' and user_password='{1}'",
                User.Account, User.Password);

            //Get information from database
            DataTable data = MySQLHelper.Query(sql);
            //If data is loaded into the User object DataTable
            if (data.Rows.Count > 0)
            {
                var row = data.Rows[0];
                //User account ID
                User.Nickname = row["user_nickname"].ToString();
            }
            //Return user infomation
            return User;
        }
    }
}
