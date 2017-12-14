using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportTablo1.Models.Statistic
{
    public partial class StatisticNameAirlineCount
    {
        public int Id { get; set; }
        public string NameAirline { get; set; }
        public Nullable<int> CountAirline { get; set; }
    }
}