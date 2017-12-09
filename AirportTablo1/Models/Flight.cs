using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public string CodeFligth { get; set; }
        public DateTime DateTimeAiplaneMove { get; set; }
        public bool IsArrive { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int TerminalId { get; set; }
        public Terminal Terminal { get; set; }
        [Required]
        public string CityArrive { get; set; }
        [Required]
        public string CityDepartment { get; set; }
        [Required]
        public string NameAirline { get; set; }
        [Display(Name = "Время задержки/прибытия заранее")]
        public DateTime DateTimeDelay { get; set; }

    }
}