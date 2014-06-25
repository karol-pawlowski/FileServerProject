using log4net;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Contracts;

namespace UserManagementService.Common
{
    public class UserRepositoryProxy : IUserRepositoryProxy
    {
        private Table<USER> _users;
        private Table<TOKEN> _tokens;
        private UserRepositoryDataContext _dataContext;
        private readonly ILog _log;

        public UserRepositoryProxy()
        {
            _dataContext = new UserRepositoryDataContext();

            _users = _dataContext.GetTable<USER>();
            _tokens = _dataContext.GetTable<TOKEN>();
            _log = LogManager.GetLogger(typeof(UserRepositoryProxy));
        }

        public bool AddNewUserToDatabase(USER user)
        {
            _users.InsertOnSubmit(user);

            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return false;
            }
            return true;
        }


        public bool CheckIfUserExistsInDatabase(string userName)
        {
            if ((from user in _users where user.Login == userName select user).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
            
        }

        public string AddNewTokenToDatabase(TOKEN token)
        {
            _tokens.InsertOnSubmit(token);

            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return "Token has not been generated";
             
            }
            return token.UserToken;
        }


        public TOKEN GetTokenForUser(string userName)
        {
            return (from token in _tokens where token.USER.Login == userName select token).FirstOrDefault();           
        }

        public void RemoveTokenFromDatabase(TOKEN tokenToRemove)
        {          
            _tokens.DeleteOnSubmit(tokenToRemove);

            try
            {
                _dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);            
            }
        }

        [System.Diagnostics.Contracts.ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            System.Diagnostics.Contracts.Contract.Invariant(_users != null);
            System.Diagnostics.Contracts.Contract.Invariant(_tokens != null);
            System.Diagnostics.Contracts.Contract.Invariant(_dataContext != null);
        }
    }
}
