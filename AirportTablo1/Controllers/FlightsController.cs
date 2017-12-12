using AirportTablo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace AirportTablo1.Controllers
{
    //    [AllowAnonymous]
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
        //List<Flight> arriveFlight;
        // GET: Flights
        public ActionResult Index(int id)
        {
            var flights = _context.Flights.Include(l => l.Status).Include(c => c.Terminal).ToList();
            List<Flight> arriveFlight = new List<Flight>();
            if (User.IsInRole("Administrator"))
            {
                if (id == 0)
                    return View("ListBefore", flights);
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
                return View("ListBefore", arriveFlight);
            }
            else
            {
                if (id == 0)
                    return View("ReadOnlyListBefore", flights);
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
                return View("ReadOnlyListBefore", arriveFlight);
            }

        }

        [HttpPost]
        public ActionResult FlightSearch(string code)
        {
            if (code == "")
            {
                return Content("");
            }
            var allFlightCode = _context.Flights.Include(m => m.Status).Include(l => l.Terminal).Where(a => a.CodeFligth.Contains(code)).ToList();
            var allFlightArrive = _context.Flights.Include(m => m.Status).Include(l => l.Terminal).Where(a => a.CityArrive.Contains(code)).ToList();
            var allFlightDeparture = _context.Flights.Include(m => m.Status).Include(l => l.Terminal).Where(a => a.CityDepartment.Contains(code)).ToList();
            List<Flight> allFlight = allFlightCode;
            allFlight.AddRange(allFlightArrive);
            allFlight.AddRange(allFlightDeparture);
            if (allFlight.Count <= 0)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Administrator"))
            {
                return PartialView("FlightSearch", allFlight);
            }
            else
            {
                return PartialView("ReadOnlyFlightSearch", allFlight);
            }
        }
        //        @Scripts.Render("~/scripts/jquery-1.10.2.js")
        //@Scripts.Render("~/scripts/jquery.unobtrusive-ajax.js")
        public ActionResult Details(int id)
        {
            var flights = _context.Flights.Include(m => m.Status).Include(l => l.Terminal).SingleOrDefault(l => l.Id == id);
            if (flights == null)
                return HttpNotFound();

            return View(flights);
        }
        public ActionResult Edit(int id)
        {
            var flight = _context.Flights.Include(l => l.Status).Include(l => l.Terminal).SingleOrDefault(m => m.Id == id);
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
            if (flight.StatusId != 0)
                flightInDb.StatusId = flight.StatusId;
            if (flight.TerminalId != 0)
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
        
        //public  ActionResult Profile(string )
        //{
        //    return View();
        //}
    }
}