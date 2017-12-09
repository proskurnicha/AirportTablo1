using AirportTablo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace AirportTablo1.Controllers
{
    [AllowAnonymous]
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
            if (User.IsInRole("Administrator"))
            {
                if (id == 0)
                    return View("List", flights);
                foreach (var item in flights)
                {
                    if (id == 1)
                    {
                        if (item.IsArrive)
                        {
                            arriveFlight.Add(item);
                        }
                    }
                    if (id == 2)
                    {
                        if (!item.IsArrive)
                        {
                            arriveFlight.Add(item);
                        }
                    }

                }
                return View("List", arriveFlight);
            }
            else
            {
                if (id == 0)
                    return View("ReadOnlyList", flights);
                foreach (var item in flights)
                {
                    if (id == 1)
                    {
                        if (item.IsArrive)
                        {
                            arriveFlight.Add(item);
                        }
                    }
                    if (id == 2)
                    {
                        if (!item.IsArrive)
                        {
                            arriveFlight.Add(item);
                        }
                    }

                }
                return View("ReadOnlyList", arriveFlight);
            }
            
        }
        public ActionResult Details(int id=0)
        {
            var flights = _context.Flights.SingleOrDefault(l => l.Id == id);
            if (flights == null)
                return HttpNotFound();

            return View(flights);
        }
        public ActionResult Edit(int id)
        {
            var flight = _context.Flights.SingleOrDefault(m => m.Id == id);
            if (flight == null)
                return HttpNotFound();
            var status = _context.Statuses.ToList();
            var terminals = _context.Terminals.ToList();
            var viewModel = new FormFlightViewModel()
            {
                Status = status,
                Terminal = terminals,
                Flight = flight
            };
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Flight flight)
        {
            var flightInDb = _context.Flights.Single(m => m.Id == flight.Id);
            flightInDb.DateTimeDelay = flight.DateTimeDelay;
            flightInDb.StatusId = flight.StatusId;
            flightInDb.TerminalId = flight.TerminalId;

            _context.SaveChanges();
            return RedirectToAction("Index", "Flights");
        }

        [Authorize]
        [HttpGet]
        public new ActionResult Profile()
        {
            return View(); 
        }
    }
}