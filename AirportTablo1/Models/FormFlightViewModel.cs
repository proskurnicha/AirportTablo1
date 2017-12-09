using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportTablo1.Models
{
    public class FormFlightViewModel
    {
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Terminal> Terminal { get; set; }
        public Flight Flight;
    }
}