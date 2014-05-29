using System.Diagnostics.Contracts;
using UserManagementService.Contracts;

namespace UserManagementService.CodeContracts
{
    [ContractClassFor(typeof(IUserRepositoryProxy))]
    public abstract class UserRepositoryProxyContract : IUserRepositoryProxy
    {
        public void AddNewUserToDatabase(USER user)
        {
            Contract.Requires(user != null);
        }

        public bool CheckIfUserExistsInDatabase(string userName)
        {
            Contract.Requires(userName != null && userName != string.Empty);
            return Contract.Result<bool>();
        }

        public string AddNewTokenToDatabase(TOKEN token)
        {
            Contract.Requires(token != null);
            return Contract.Result<string>();
        }

        public TOKEN GetTokenForUser(string userName)
        {
            Contract.Requires(userName != null && userName != string.Empty);
            return Contract.Result<TOKEN>();
        }

        public void RemoveTokenFromDatabase(TOKEN tokenToRemove)
        {
            Contract.Requires(tokenToRemove != null);
        }
    }
}