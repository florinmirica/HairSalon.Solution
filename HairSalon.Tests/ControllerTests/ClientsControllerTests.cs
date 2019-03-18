using HairSalon.Solution.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static HairSalon.Startup;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class ClientsControllerTests
    {
       
        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            //Act
            ViewResult indexView = controller.New(4) as ViewResult;
            
            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            IActionResult indexView = controller.View(2) as ViewResult;

            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectActionType_ViewResult()
        {
            ClientsController controller = new ClientsController();
            IActionResult view = controller.Show(1);
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        public ClientsControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica_test;";
        }
    } 
}
