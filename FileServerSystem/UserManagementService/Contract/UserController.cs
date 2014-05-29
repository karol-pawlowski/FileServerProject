using System;
using UserManagementService.Contracts;
using UserManagementService.Common;

namespace UserManagementService
{
    public class UserController : IUserController
    {
        private IUserRepositoryProxy _proxy;     
        private readonly IBootStrapper _bootstrapper;

        public UserController()
        {
            _proxy = new UserRepositoryProxy();
            _bootstrapper = new BootStrapper();

            _bootstrapper.InitializeApplication();
        }

        public UserController(IUserRepositoryProxy proxy, IBootStrapper bootstrapper)
        {
            _proxy = proxy;
            _bootstrapper = bootstrapper;

            _bootstrapper.InitializeApplication();
        }

        public string RegisterNewUser(string userName, string password)
        {
            USER user = new USER();
            user.Login = userName;
            user.Password = password;

            _proxy.AddNewUserToDatabase(user);            
            
            return "User has been added";        
        }

        public string UserLogin(string userName, string password)
        {
            if (_proxy.CheckIfUserExistsInDatabase(userName))
            {
                TOKEN token = new TOKEN();
                token.Login = userName;
                token.UserToken = Guid.NewGuid().ToString();
                token.Is_Active = true;

                return _proxy.AddNewTokenToDatabase(token);
            }
            else
            {               
                return "User is not registered";
            }         
        }

        public string UserLogOff(string userName)
        {
            if (_proxy.CheckIfUserExistsInDatabase(userName))
            {
                TOKEN tokenToRemove = _proxy.GetTokenForUser(userName);

                _proxy.RemoveTokenFromDatabase(tokenToRemove);              
            }
            else
            {
                return "User is not registered";
            }

            return "User has been logged off";
        }
        
    }
}
