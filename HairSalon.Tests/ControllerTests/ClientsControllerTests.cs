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

        public ClientsControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica;";
        }
    } 
}
