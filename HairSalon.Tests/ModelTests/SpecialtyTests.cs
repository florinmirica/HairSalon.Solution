using HairSalon.Controllers;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static HairSalon.Startup;


namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica_test;";
        }

        public void Dispose()
        {
            Specialty.DeleteAll();
        }

        [TestMethod]
        public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
        {
            string specialty = "The expert";
            Specialty newSpecialty = new Specialty(specialty);

            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }
        [TestMethod]
        public void Delete_DeletesSpecialtyFromDatabase()
        {
            string specialty = "Artist";
            Specialty newSpecialty = new Specialty(specialty);
            newSpecialty.Save();
            newSpecialty.Delete();

            List<Specialty> newList = new List<Specialty> { newSpecialty };
            List<Specialty> resultList = Specialty.GetAll();

            CollectionAssert.AreNotEqual(newList, resultList);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllStylistsFromDatabase()
        {
            string specialty = "Superman";
            Specialty newSpecialty = new Specialty(specialty);
            newSpecialty.Save();
            Specialty.DeleteAll();

            List<Specialty> newList = new List<Specialty> { newSpecialty };
            List<Specialty> resultList = Specialty.GetAll();

            CollectionAssert.AreNotEqual(newList, resultList);
        }

    }
}
        
