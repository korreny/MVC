using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GetDBInfo.BLL;
using GetDBInfo;

using GetDBInfo.Model;
using com.iflysse.helper;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        //GET :http://localhost:55039/jcservice/User?account=admin&password=admin

        /// <summary>
        /// User Data List
        /// </summary>
        private readonly List<User> _userList = new List<User>
        {
            new User {Id = "1", Account = "Superman", Nickname = "Superman@cnblogs.com"},
            new User {Id = "2", Account = "Spiderman", Nickname = "Spiderman@cnblogs.com"},
            new User {Id = "3", Account = "Batman", Nickname = "Batman@cnblogs.com"}
        };

        //// GET api/User
        //public IEnumerable<User> Get()
        //{
        //    return _userList;
        //}

        //// GET api/User/5
        //public User GetUserByID(int id)
        //{
        //    var user = _userList.FirstOrDefault(User => User.Id == id.ToString());
        //    if (user == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return user;
        //}

        ////GET api/User/?username=xx
        //public IEnumerable<User> GetUserByName(string userName,int id)
        //{
        //    return _userList.Where(p => string.Equals(p.Nickname,userName, StringComparison.OrdinalIgnoreCase));
        //}

        //GET api/User/?username=xx
        public WebApi GetUserByName(string account,string password)
        {
            GetDBInfo.BLL.UserServiceBLL userMessage = new GetDBInfo.BLL.UserServiceBLL();
            GetDBInfo.Model.User user = new GetDBInfo.Model.User();
            user.Account = account;
            user.Password = password;
            userMessage.UserLogin(user);

            WebApi _webApi = new WebApi
            {
                Code = 1,
                Msg = "Request Success!",
                Data = userMessage.UserLogin(user)
            };
            if (_userList[0].Id == null)
            {
                _webApi.Data = null;
            }
            return _webApi;
         }

        ////POST api/User/User Entity Json
        //public User Add([FromBody]User User)
        //{
        //    if (User == null)
        //    {
        //        throw new HttpRequestException();
        //    }
        //    _userList.Add(User);
        //    return User;
        //}

        //public void Delete(int id)
        //{
        //    _userList.RemoveAll(p => p.Id == id.ToString());
        //}
    }
}