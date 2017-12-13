using AirportTablo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportTablo1.Controllers
{
    public class PassangersController : Controller
    {
        private ApplicationDbContext _context;
        public PassangersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Passangers
        public ActionResult Index()
        {
            return View();
        }
    }
}