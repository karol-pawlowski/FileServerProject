using System.Diagnostics.Contracts;
using UserManagementService.Contracts;

namespace UserManagementService.CodeContracts
{
    [ContractClassFor(typeof(IUserRepositoryProxy))]
    public abstract class UserRepositoryProxyContract : IUserRepositoryProxy
    {
        public bool AddNewUserToDatabase(USER user)
        {
            System.Diagnostics.Contracts.Contract.Requires(user != null);
            return System.Diagnostics.Contracts.Contract.Result<bool>();
        }

        public bool CheckIfUserExistsInDatabase(string userName)
        {
            System.Diagnostics.Contracts.Contract.Requires(userName != null && userName != string.Empty);
            return System.Diagnostics.Contracts.Contract.Result<bool>();
        }

        public string AddNewTokenToDatabase(TOKEN token)
        {
            System.Diagnostics.Contracts.Contract.Requires(token != null);
            return System.Diagnostics.Contracts.Contract.Result<string>();
        }

        public TOKEN GetTokenForUser(string userName)
        {
            System.Diagnostics.Contracts.Contract.Requires(userName != null && userName != string.Empty);
            return System.Diagnostics.Contracts.Contract.Result<TOKEN>();
        }

        public void RemoveTokenFromDatabase(TOKEN tokenToRemove)
        {
            System.Diagnostics.Contracts.Contract.Requires(tokenToRemove != null);
        }
    }
}