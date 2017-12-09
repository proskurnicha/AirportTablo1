using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        [Required]
        public string TerminalInfo { get; set; }
    }
}