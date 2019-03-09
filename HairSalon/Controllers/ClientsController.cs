﻿using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Solution.Controllers
{
    public class ClientsController : Controller
    {

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

    }
}
