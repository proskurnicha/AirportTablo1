using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportTablo1.Models
{
    public class CheckViewModels
    {
        public int delay;
        public bool changeTerminal;
        public string terminal;
        public CheckViewModels()
        {
            delay = 0;
            changeTerminal = false;
            terminal = "";
        }
    }
}