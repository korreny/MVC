using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetDBInfo.Model
{
    public class User
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        private string currentCity;

        public string CurrentCity
        {
            get { return currentCity; }
            set { currentCity = value; }
        }
        private string maidservant;

        public string Maidservant
        {
            get { return maidservant; }
            set { maidservant = value; }
        }
        private string registerTime;

        public string RegisterTime
        {
            get { return registerTime; }
            set { registerTime = value; }
        }
        private string vip;

        public string Vip
        {
            get { return vip; }
            set { vip = value; }
        }

    }
}
