using AirportTablo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirportTablo1.Controllers.API
{
    public class CheckController : ApiController
    {
        private ApplicationDbContext _context;
        public CheckController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public CheckViewModels Get(string id, string terminal)
        {
            CheckViewModels checkViewModels = new CheckViewModels();
            var passanger = _context.Passangers.FirstOrDefault(m => m.AspNetUsersId == id);
            var flight = _context.Flights.FirstOrDefault(m => m.Id == passanger.FlightId);
            //   var terminalDb = _context.Terminals.FirstOrDefault(m => m.TerminalInfo == terminal);
            if (flight.Terminal.TerminalInfo == terminal)
            {
                checkViewModels.changeTerminal = false;
            }
            else
            {
                checkViewModels.changeTerminal = true;
                checkViewModels.terminal = flight.Terminal.TerminalInfo;
            }
            //forMessageViewModel.flightNumber = flight.CodeFligth;
            //var terminal = _context.Terminals.FirstOrDefault(m => m.Id == flight.TerminalId);
            //forMessageViewModel.terminal = terminal.TerminalInfo;

            ////string date = dateMove.Minute + " " + dateMove.Second;
            //TimeSpan timeSpan = flight.DateTimeAiplaneMove - DateTime.Now;
            //forMessageViewModel.timeBeforeFlight = Convert.ToInt32(timeSpan.Days * 24 * 60 + timeSpan.Hours * 60 + timeSpan.Minutes);
            ////forMessageViewModel.timeBeforeFlight = date;

            return checkViewModels;
        }
    }
}
