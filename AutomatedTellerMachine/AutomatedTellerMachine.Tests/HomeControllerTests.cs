using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Controllers;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void SerialActionReturnsContentToLowerIfLower()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Serial("lower") as ContentResult;

            //Assert
            Assert.AreEqual("test", result.Content);
        }

        [TestMethod]
        public void SerialActionReturnsSameContentIfNotLower()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Serial("message") as ContentResult;

            //Assert
            Assert.AreEqual("TEST", result.Content);
        }

        [TestMethod]
        public void ContactActionPostReturnsRightMessageToTheUser()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Contact("Want to complain") as ViewResult;

            //Assert
            Assert.AreEqual("We got your message.Thank you", result.ViewBag.CustomerMessage);
        }
    }
}
