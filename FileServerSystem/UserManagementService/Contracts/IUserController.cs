
using System.ServiceModel;
namespace UserManagementService.Contracts
{    
    [ServiceContract]
    public interface IUserController
    {
        /// <summary>
        /// Register new user and return new token
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns>Token</returns>
        [OperationContract]
        string RegisterNewUser(string userName, string password);

        /// <summary>
        /// User login and return new token assigned
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [OperationContract]
        string UserLogin(string userName, string password);

        /// <summary>
        /// User Log off
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <returns>Nothing</returns>
        [OperationContract]
        string UserLogOff(string userName);
    }
}
