using HairSalon.Controllers;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static HairSalon.Startup;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class StylistsControllerTests
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_ItemList()
        {
            //Arrange
            ViewResult indexView = new StylistsController().Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
            StylistsController controller = new StylistsController();

            //Act
            IActionResult indexView = controller.New();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_StylistList()
        {
            StylistsController controller = new StylistsController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

       // [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult createView = controller.Create("Dan");
            Assert.IsInstanceOfType(createView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_CreatesNewInstanceOfStylist_True()
        {
            ActionResult createPost = new StylistsController().Create("Daniel");
            Assert.IsInstanceOfType(createPost, typeof(ActionResult));
        }

        

        public StylistsControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica_test;";
        }
    }
}
