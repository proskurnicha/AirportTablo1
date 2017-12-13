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

            var user = _context.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return  new CheckViewModels();
            }
            var passanger = _context.Passangers.FirstOrDefault(m => m.AspNetUsersId == user.Id);
            if (passanger == null)
            {
                return new CheckViewModels();
            }
            
            var flight = _context.Flights.FirstOrDefault(m => m.Id == passanger.FlightId);

            var terminalDB = _context.Terminals.FirstOrDefault(m => m.Id == flight.TerminalId);
            if (terminalDB.TerminalInfo == terminal)
            {
                checkViewModels.changeTerminal = false;
            }
            else
            {
                checkViewModels.changeTerminal = true;
                checkViewModels.terminal = flight.Terminal.TerminalInfo;
            }
            int hours = Convert.ToInt32(flight.TimeDelay.TotalHours)*60;
            int minutes = Convert.ToInt32(flight.TimeDelay.TotalMinutes);
            checkViewModels.delay = hours + minutes;
               
            return checkViewModels;
        }
    }
}
