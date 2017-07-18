using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GetDBInfo.DAL;
using GetDBInfo.Model;

namespace GetDBInfo.BLL
{
    /// <summary>
    /// FileName: UserMessager.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: ranli2
    /// Corporation: iosten
    /// Description: user business logic class
    /// DateTime: 2017-05-01 09:40:53
    /// </summary>
    public class UserMessager
    {
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UserLogin(User user)
        {
            return new UserService().UserLogin(user);
        }
    }
}
