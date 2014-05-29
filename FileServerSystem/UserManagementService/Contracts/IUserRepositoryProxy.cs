using System.Diagnostics.Contracts;
using UserManagementService.CodeContracts;

namespace UserManagementService.Contracts
{
    [ContractClass(typeof(UserRepositoryProxyContract))]
    public interface IUserRepositoryProxy
    {
        void AddNewUserToDatabase(USER user);
        bool CheckIfUserExistsInDatabase(string userName);
        string AddNewTokenToDatabase(TOKEN token);
        TOKEN GetTokenForUser(string userName);
        void RemoveTokenFromDatabase(TOKEN tokenToRemove);
    }
}
