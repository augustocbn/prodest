using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Controllers
{
    public class TravelerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.VisiterName = "Augusto Nunes";
            return View();
        }
    }
}
