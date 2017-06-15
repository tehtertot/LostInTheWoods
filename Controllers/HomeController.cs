using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostInTheWoods.Models;
using lostInTheWoods.Factory;

namespace lostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(TrailFactory tf) {
            trailFactory = tf;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.All();
            return View();
        }
        
        [HttpGet]
        [Route("add")]
        public IActionResult NewTrail() {
            return View();
        }
        
        [HttpGet]
        [Route("view/{id}")]
        public IActionResult View(int id) {
            ViewBag.trail = trailFactory.GetById(id);
            return View();
        }

        [HttpPost]
        [Route("newTrail")]
        public IActionResult AddTrail(Trail t, string NS, string EW) {
            if (NS == "S" && t.Latitude > 0) {
                t.Latitude = t.Latitude * -1;
            }
            if (EW == "W" && t.Longitude > 0) {
                t.Longitude = t.Longitude * -1;
            }
            if (ModelState.IsValid) {
                trailFactory.Add(t);
                return RedirectToAction("Index");
            }
            else {
                
                return View("NewTrail");
            }

        }
    }
}
