using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    public class Passangers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Passport { get; set; }
        [MaxLength(128)]
        public string AspNetUsersId { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int SeatNumber { get; set; }
    }
}