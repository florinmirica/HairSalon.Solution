using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Solution.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public IActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View(model);
        }

        [HttpGet("/clients/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Client stylist = Client.Find(id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("clientId", id);
            model.Add("clientName", stylist.GetName());
            return View(model);
        }

        [HttpPost("/clients/{clientId}/edit")]
        public ActionResult Edit(string clientName, int clientId)
        {
            Client newclient = Client.Find(clientId);
            newclient.SetName(clientName);
            newclient.Update();
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(newclient.GetStylistId());
            model.Add("client", newclient);
            model.Add("stylist", stylist);
            return View("Show", model);
        }


        [HttpGet("/stylist/{id}/show/clients")]
        public ActionResult Show(int id)
        {
            return View(id);
        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client newClient = Client.Find(id);
            newClient.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/deleteall")]
        public ActionResult DeleteAll(int id)
        {
            Client.DeleteAll();
            return RedirectToAction("Index");
        }

    }
}
