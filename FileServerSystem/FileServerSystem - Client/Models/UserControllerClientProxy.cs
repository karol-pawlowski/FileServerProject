using FileServerSystemClient.Contracts;
using FileServerSystemClient.UserManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileServerSystemClient.Models
{
    public class UserControllerClientProxy : IUserControllerClientProxy
    {
        UserControllerClient _client;

        public UserControllerClientProxy(){         
           
            _client = new UserControllerClient();
        }

        public void GenerateNewUser(string userName, string password)
        {
            _client.RegisterNewUser(userName, password);
        }
    }
}