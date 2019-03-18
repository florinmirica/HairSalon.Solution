using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public IActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/stylists/{stylistId}/specialty/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/specialties/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Specialty specialty = Specialty.Find(id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("specialtyId", id);
            model.Add("specialtyName", specialty.GetName());
            return View(model);
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string specialtyName)
        {
            Specialty newSpecialty = new Specialty(specialtyName);
            newSpecialty.Save();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }

        [HttpGet("/specialties/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty selectedSpecialty = Specialty.Find(id);
            List<Stylist> stylists = selectedSpecialty.GetStylists();
            model.Add("specialty", selectedSpecialty);
            model.Add("stylists", stylists);
            return View(model);
        }

        [HttpPost("/specialties/{specialtyId}/stylists")]
        public ActionResult Create(int specialtyId, string stylistName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty foundSpecialty = Specialty.Find(specialtyId);
            Stylist stylist = new Stylist(stylistName);
            stylist.Save();
            stylist = Stylist.FindByName(stylistName);
            foundSpecialty.AddStylist(specialtyId, stylist.GetId());
            List<Stylist> stylists = foundSpecialty.GetStylists();
            model.Add("stylists", stylists);
            model.Add("specialty", foundSpecialty);
            return View("Show", model);
        }

        [HttpGet("/specialties/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Specialty newSpecialty = Specialty.Find(id);
            newSpecialty.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/deleteall")]
        public ActionResult DeleteAll(int id)
        {
            Specialty.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}