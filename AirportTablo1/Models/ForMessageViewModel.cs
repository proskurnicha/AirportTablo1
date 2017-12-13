using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportTablo1.Models
{
    public class ForMessageViewModel
    {
        public string fcs;
        public string terminal;
        public string flightNumber;
        public int timeBeforeFlight;
        public bool noFlight;
        public ForMessageViewModel()
        {
            fcs = "";
            terminal = "";
            flightNumber = "";
            timeBeforeFlight = 0;
            noFlight = true;
        }
    }
}