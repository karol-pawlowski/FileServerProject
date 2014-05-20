using FileServerSystem___Server.Contracts;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FileServerSystem___Server.Controllers
{
    public class UserController : Controller, IUserController
    {
        private IDictionary<string, string> users;
        private IDictionary<string, Guid> tokens;

        public UserController()
        {
            users = new Dictionary<string, string>();
            tokens = new Dictionary<string, Guid>();
        }

        public string RegisterNewUser(string userName, string password)
        {
            users.Add(userName, password);

            return "User has been added";
        }

        public string UserLogin(string userName, string password)
        {
            if (users.ContainsKey(userName))
            {
                tokens.Add(userName, Guid.NewGuid());
            }
            else
            {
                return "User is not registered";
            }

            return tokens[userName].ToString();
        }

        public string UserLogOff(string userName)
        {
            if (users.ContainsKey(userName))
            {
                tokens.Remove(userName);
            }
            else
            {
                return "User is not registered";
            }

            return "User has been logged off";
        }
    }
}
