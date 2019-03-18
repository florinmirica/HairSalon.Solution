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
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=florin_mirica_test;";
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client("John", 3);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void Delete_DeletesClientFromDatabase()
        {
            string name = "Brian O'Conner";
            int stylistId = 1;
            Client newClient = new Client(name, stylistId);
            newClient.Save();
            newClient.Delete();

            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { newClient };

            CollectionAssert.AreNotEqual(testList, result); ;
        }

        [TestMethod]
        public void DeleteAll_DeletesAllClientsFromDatabase()
        {
            string name = "Brian O'Conner";
            int stylistId = 1;
            Client newClient = new Client(name, stylistId);
            newClient.Save();
            Client.DeleteAll();

            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { newClient };

            CollectionAssert.AreNotEqual(testList, result); ;



        }
    }

}