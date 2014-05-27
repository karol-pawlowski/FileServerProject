using FileServerSystem___Server.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using System.Linq;

namespace FileServerSystem___Server.Controllers
{
    public class UserController : Controller, IUserController
    {
        private Table<USER> _users;
        private Table<TOKEN> _tokens;
        private DataDataContext _dataContext;        

        public UserController()
        {
            _dataContext = new DataDataContext();

            _users = _dataContext.GetTable<USER>();
            _tokens = _dataContext.GetTable<TOKEN>();            
        }

        public string RegisterNewUser(string userName, string password)
        {
            Contract.Requires(userName != null && password != null & userName != string.Empty & password != string.Empty);           

            Table<USER> users = _dataContext.GetTable<USER>();
            users.InsertOnSubmit(new USER(userName, password));

            Contract.Ensures(Contract.Result<string>() != string.Empty);
            return "User has been added";
        }

        public string UserLogin(string userName, string password)
        {
            Contract.Requires(userName != null && password != null & userName != string.Empty & password != string.Empty);
            
            if ((from user in _users where user.Login == userName select user).FirstOrDefault() != null)
            {
                _tokens.InsertOnSubmit(new TOKEN(userName, Guid.NewGuid().ToString()));
            }
            else
            {
                return "User is not registered";
            }

            Contract.Ensures(Contract.Result<string>() != string.Empty);

            return (from token in _tokens where token.USER.Login == userName select token).FirstOrDefault().ToString();
        }

        public string UserLogOff(string userName)
        {
            Contract.Requires(userName != null & userName != string.Empty);

            if ((from user in _users where user.Login == userName select user).FirstOrDefault() != null)
            {
                _tokens.DeleteOnSubmit((from token in _tokens where token.USER.Login == userName select token).FirstOrDefault());
            }
            else
            {
                return "User is not registered";
            }

            Contract.Ensures(Contract.Result<string>() != string.Empty);

            return "User has been logged off";
        }

        [ContractInvariantMethod]
        protected void ObjectInvariant () 
        {
            Contract.Invariant(_users != null);
            Contract.Invariant(_tokens != null);
            Contract.Invariant(_dataContext != null);
        }
    }
}
