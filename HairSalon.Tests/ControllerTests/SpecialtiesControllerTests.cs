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
    public class SpecialtiesControllerTest
    {

        public SpecialtiesControllerTest()
        {
            {
                DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica_test;";
            }
        }

            [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            IActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_SpecialtyList()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }

        [TestMethod]
        public void New_ReturnsCorrect_View_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult indexView = controller.New();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectActionType_ViewResult()
        {
            SpecialtiesController controller = new SpecialtiesController();
            IActionResult indexView = controller.Show(3);
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }


    }

    }

