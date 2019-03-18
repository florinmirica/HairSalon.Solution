using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public IActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/specialties/{specialtyId}/stylists/new")]
        public ActionResult New(int specialtyId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            return View(specialty);
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Stylist stylist = Stylist.Find(id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("stylistId", id);
            model.Add("stylistName", stylist.GetName());
            return View(model);
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string stylistName)
        {
            Stylist newStylist = new Stylist(stylistName);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpPost("/stylists/{stylistId}/edit")]
        public ActionResult Edit(string stylistName, int stylistId)
        {
            Stylist newStylist = new Stylist(stylistName, stylistId);
            newStylist.Update();
            Dictionary<string, object> model = new Dictionary<string, object>();
            List<Client> clients = newStylist.GetClients();
            model.Add("stylist", newStylist);
            model.Add("clients", clients);
            return View("Show", model);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> clients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", clients);
            model.Add("specialties", selectedStylist.GetSpecialties());
            return View(model);
        }

        // This creates new Items within a given Category, not new Categories:
        [HttpPost("/stylists/{stylistId}/clients")]
        public ActionResult Create(int stylistId, string clientName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            List<Client> clients = foundStylist.GetClients();
            List<Specialty> specialties = foundStylist.GetSpecialties();
            model.Add("clients", clients);
            model.Add("stylist", foundStylist);
            model.Add("specialties", specialties);
            return View("Show", model);
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist newStylist = Stylist.Find(id);
            newStylist.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/deleteall")]
        public ActionResult DeleteAll(int id)
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/specialties")]
        public ActionResult CreateSpecialty(int stylistId, string specialtyName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Specialty specialty = new Specialty(specialtyName);
            specialty.Save();
            specialty = Specialty.FindByName(specialtyName);
            specialty.AddStylist(specialty.GetId(), stylistId);
            List<Specialty> specialties = foundStylist.GetSpecialties();
            List<Client> clients = foundStylist.GetClients();
            model.Add("stylist", foundStylist);
            model.Add("specialties", specialties);
            model.Add("clients", clients);
            return View("Show", model);
        }
    }
}