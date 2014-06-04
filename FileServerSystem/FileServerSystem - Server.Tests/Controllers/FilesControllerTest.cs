using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileServerSystemServer;
using FileServerSystemServer.Controllers;
using FileServerSystemServer.Contracts;
using NSubstitute;
using FileServerSystem.Tests.Controllers;

namespace FileServerSystemServer.Tests.Controllers
{
    [TestClass]
    public class FilesControllerTest
    {
        [TestMethod]
        public void Get()
        { 
            // Arrange
            IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            IFileRepositoryProxy proxyMock = Substitute.For<IFileRepositoryProxy>();

            FilesController controller = new FilesController(bootStrapperMock, proxyMock);

            proxyMock.GetFilesForToken("testToken").Returns(new List<string>() { "File.exe", "Image.jpg", "Document.txt"});

            // Act
            IEnumerable<string> result = controller.Get("testToken");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("File.exe", result.ElementAt(0));
            Assert.AreEqual("Image.jpg", result.ElementAt(1));
            Assert.AreEqual("Document.txt", result.ElementAt(2));
        }

        [TestMethod]
        public void GetById()
        {
            //// Arrange
            //IBootStrapper bootStrapperMock = Substitute.For<IBootStrapper>();
            //IFileRepositoryProxy proxyMock = Substitute.For<IFileRepositoryProxy>();

            //FilesController controller = new FilesController(bootStrapperMock, proxyMock);

            //proxyMock.GetSpecificFileForTokenAndId("testToken", 1);

            //// Act
            //HttpResponseMessage result = controller.Get("testToken", 1);

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            //FilesController controller = new FilesController();

            //// Act
            //controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            //// Arrange
            //FilesController controller = new FilesController();

            //// Act
            //controller.Put(5, "value");

            //// Assert
        }

        [TestMethod]
        public void Delete()
        {
            //// Arrange
            //FilesController controller = new FilesController();

            //// Act
            //controller.Delete(5);

            //// Assert
        }
    }
}
