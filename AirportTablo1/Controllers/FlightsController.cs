using AirportTablo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace AirportTablo1.Controllers
{
    public class FlightsController : Controller
    {
        private ApplicationDbContext _context;
        public FlightsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Flights
        public ActionResult Index(int id)
        {
            var flights = _context.Flights.Include(l => l.Status).Include(c => c.Terminal).ToList();
            List<Flight> arriveFlight = new List<Flight>();
            foreach (var item in flights)
            {

                if (item.IsArrive)
                {
                    arriveFlight.Add(item);
                }
            }
            return View(arriveFlight);
        }
        public ActionResult Details(int id)
        {
            var flights = _context.Flights.SingleOrDefault(l => l.Id == id);
            if (flights == null)
                return HttpNotFound();

            return View(flights);
        }
    }
}