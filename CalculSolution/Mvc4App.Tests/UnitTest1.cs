using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Logger.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc4App.Controllers;
using Moq;

namespace Mvc4App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get5Test()
        {
            // Arrange
            var mock = new Mock<Logger.Abstract.IRepository>();
            mock.Setup(x => x.Get5(5)).Returns(new List<Record>
                {
                    new Record(),
                    new Record(),
                    new Record(),
                    new Record(),
                    new Record(),
                });


            HistoryController controller = new HistoryController(mock.Object);

            // Act
            ViewResult result = controller.Get5() as ViewResult;

            // Assert
            Assert.AreEqual(false, result.Model);
        }

        
    }
}
