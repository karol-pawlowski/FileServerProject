using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Common;
using UserManagementService.Contracts;

namespace FileServerSystem.Tests.Controllers
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

       
    }
}
