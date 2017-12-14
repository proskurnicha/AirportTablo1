using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AirportTablo1.Models
{
    public class StatisticAirline
    {
        public int CountAirline;
        public string NameAirline;
        public StatisticAirline(int countAirline, string nameAirline)
        {
            CountAirline = countAirline;
            NameAirline = nameAirline;
        }
        public StatisticAirline()
        {

        }
    }
    public class StatisticTerminal
    {
        public string TerminalInfo;
        public int CountTerminal;
        public StatisticTerminal(string terminalInfo, int countTerminal)
        {
            TerminalInfo = terminalInfo;
            CountTerminal = countTerminal;
        }
        public StatisticTerminal()
        {

        }

    }
    public class Statistic
    {
        List<StatisticTerminal> statisticTerminal;
        List<StatisticAirline> statisticAirline;
        public Statistic(List<StatisticTerminal> statisticTerminal, List<StatisticAirline> statisticAirline)
        {
            this.statisticAirline = statisticAirline;
            this.statisticTerminal = statisticTerminal;
        }
    }

}