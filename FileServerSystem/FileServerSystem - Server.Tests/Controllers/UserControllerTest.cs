using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Common;
using UserManagementService.Contracts;

namespace FileServerSystemServer.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void CreationNewUserTest()
        {
            IUserRepositoryProxy proxyMock = NSubstitute.Substitute.For<IUserRepositoryProxy>();
            IBootStrapper bootStrapperMock = NSubstitute.Substitute.For<IBootStrapper>();

            UserController userController = new UserController(proxyMock, bootStrapperMock);

            var result = userController.RegisterNewUser("Karol", "Password");

            Assert.AreEqual("User has been added", result);
        }

        [TestMethod]
        public void UserLoginTest()
        {
            IUserRepositoryProxy proxy = NSubstitute.Substitute.For<IUserRepositoryProxy>();
            IBootStrapper bootStrapper = NSubstitute.Substitute.For<IBootStrapper>();

            UserController userController = new UserController(proxy, bootStrapper);

            var result = userController.UserLogin("Karol", "Password");

            Assert.AreEqual("User is not registered", result);
        }

        public void RegisterNewUserWhereUserDoesNotExist()
        {
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IUserRepositoryProxy userRepositoryProxy = Substitute.For<IUserRepositoryProxy>();
            IUserController _userController = new UserController(userRepositoryProxy, bootStrapperMock);

            userRepositoryProxy.AddNewUserToDatabase(null).ReturnsForAnyArgs(true);

            // Act
            string result = _userController.RegisterNewUser("Karol", "Password");

            // Assert
            Assert.AreEqual("User has been added", result);
            userRepositoryProxy.ReceivedWithAnyArgs().AddNewUserToDatabase(null);
        }

        [TestMethod]
        public void RegisterNewUserDoesExist()
        {
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IUserRepositoryProxy userRepositoryProxy = Substitute.For<IUserRepositoryProxy>();
            IUserController userController = new UserController(userRepositoryProxy, bootStrapperMock);

            userRepositoryProxy.AddNewUserToDatabase(null).ReturnsForAnyArgs(false);

            // Act
            string result = userController.RegisterNewUser("Karol", "Password");

            // Assert
            Assert.AreEqual("User has not been added", result);
            userRepositoryProxy.ReceivedWithAnyArgs().AddNewUserToDatabase(null);
        }

        [TestMethod]
        public void UserLoginWhereUserDoesNotExist()
        {
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IUserRepositoryProxy userRepositoryProxy = Substitute.For<IUserRepositoryProxy>();
            IUserController userController = new UserController(userRepositoryProxy, bootStrapperMock);

            userRepositoryProxy.CheckIfUserExistsInDatabase("Karol").Returns(false);
            userRepositoryProxy.AddNewTokenToDatabase(null).ReturnsForAnyArgs("testToken");

            // Act
            string result = userController.UserLogin("Karol", "Password");

            // Assert
            Assert.AreEqual("User is not registered", result);
            userRepositoryProxy.ReceivedWithAnyArgs().CheckIfUserExistsInDatabase(null);            
        }

        [TestMethod]
        public void UserLoginWhereUserDoesExist()
        {
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IUserRepositoryProxy userRepositoryProxy = Substitute.For<IUserRepositoryProxy>();
            IUserController userController = new UserController(userRepositoryProxy, bootStrapperMock);

            userRepositoryProxy.CheckIfUserExistsInDatabase("Karol").Returns(true);
            userRepositoryProxy.AddNewTokenToDatabase(null).ReturnsForAnyArgs("testToken");

            // Act
            string result = userController.UserLogin("Karol", "Password");

            // Assert
            Assert.AreEqual("testToken", result);
            userRepositoryProxy.ReceivedWithAnyArgs().CheckIfUserExistsInDatabase(null);
            userRepositoryProxy.ReceivedWithAnyArgs().AddNewTokenToDatabase(null);
        }

        [TestMethod]
        public void UserLogOff()
        {
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IUserRepositoryProxy userRepositoryProxy = Substitute.For<IUserRepositoryProxy>();
            IUserController userController = new UserController(userRepositoryProxy, bootStrapperMock);

            userRepositoryProxy.CheckIfUserExistsInDatabase("Karol").Returns(true);
            userRepositoryProxy.GetTokenForUser("Karol").Returns(new UserManagementService.TOKEN());
            userRepositoryProxy.RemoveTokenFromDatabase(null);

            // Act
            string result = userController.UserLogOff("Karol");

            // Assert
            Assert.AreEqual("User has been logged off", result);
            userRepositoryProxy.ReceivedWithAnyArgs().CheckIfUserExistsInDatabase(null);
            userRepositoryProxy.ReceivedWithAnyArgs().GetTokenForUser("Karol");
            userRepositoryProxy.ReceivedWithAnyArgs().RemoveTokenFromDatabase(null);
        }
    }
}
