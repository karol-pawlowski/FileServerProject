using FileServerSystemClient.Contracts;
using FileServerSystemClient.Controllers;
using FileServerSystemClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FileServerSystem.Tests.Controllers
{

    // atribute needed to say to the compiler that this is a class for testing 
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void GenerateNewUserTest()
        {
            /** Testing is a process that can be divided to 3 parts
             *  
             *  First part is Arrange
             *  Second is Act 
             *  Third Assert
             *  
             **/

            // Arrange
            // this is a mock used to test whether the method call the web service
            IUserControllerClientProxy proxyMock = Substitute.For<IUserControllerClientProxy>();
            Login user = new Login();
            user.Username = "Karol";
            user.Password = "Password";

            //Act
            LoginController controller = new LoginController(proxyMock, user);
            controller.CreateNewUser();

            //Assert
            proxyMock.Received().GenerateNewUser(user.Username, user.Password);
        }
    }
}
