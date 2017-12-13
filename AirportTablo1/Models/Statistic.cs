using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    [Table("dbo.StatisticNameAirline")]
    public class StatisticAirline
    {
        public int CountAirline;
        public string NameAirline;
    }
}