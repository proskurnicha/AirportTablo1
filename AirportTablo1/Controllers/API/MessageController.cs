using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirportTablo1.Models;
namespace AirportTablo1.Controllers.API
{
    public class MessageController : ApiController
    {
        private ApplicationDbContext _context;
        public MessageController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ForMessageViewModel Get(string id)
        {
            ForMessageViewModel forMessageViewModel = new ForMessageViewModel();
            var passanger = _context.Passangers.FirstOrDefault(m => m.AspNetUsersId == id);
            forMessageViewModel.fcs = passanger.FirstName + " " + passanger.SecondName;
            var flight = _context.Flights.FirstOrDefault(m => m.Id == passanger.FlightId);
            forMessageViewModel.flightNumber = flight.CodeFligth;
            var terminal = _context.Terminals.FirstOrDefault(m => m.Id == flight.TerminalId);
            forMessageViewModel.terminal = terminal.TerminalInfo;

            //string date = dateMove.Minute + " " + dateMove.Second;
            TimeSpan timeSpan = flight.DateTimeAiplaneMove - DateTime.Now;
            forMessageViewModel.timeBeforeFlight = Convert.ToInt32(timeSpan.Days * 24 * 60 + timeSpan.Hours * 60 + timeSpan.Minutes);
            //forMessageViewModel.timeBeforeFlight = date;

            return forMessageViewModel;
        }

    }
}
