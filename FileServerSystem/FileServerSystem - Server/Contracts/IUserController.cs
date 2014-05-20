
namespace FileServerSystem___Server.Contracts
{
    public interface IUserController
    {
        /// <summary>
        /// Register new user and return new token
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns>Token</returns>
        string RegisterNewUser(string userName, string password);

        /// <summary>
        /// User login and return new token assigned
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        string UserLogin(string userName, string password);

        /// <summary>
        /// User Log off
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <returns>Nothing</returns>
        string UserLogOff(string userName);
    }
}
