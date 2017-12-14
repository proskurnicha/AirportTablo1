using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    public partial class StatisticTerminalCount
    {
        public int Id { get; set; }
        public string TerminalInfo { get; set; }
        public Nullable<int> CountTerminal { get; set; }
    }
}