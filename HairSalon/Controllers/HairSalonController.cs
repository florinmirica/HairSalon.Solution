using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class HairSalonController : Controller
    {
        [Route("/hairsalon")]
        public IActionResult Index()
        {
            return View();
        }
    }
}