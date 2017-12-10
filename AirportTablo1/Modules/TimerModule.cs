using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AirportTablo1.Modules
{
    public class TimerModule: IHttpModule
    {
            static Timer timer;
            long interval = 30000; //30 секунд
            static object synclock = new object();
            static bool sent = false;

            public void Init(HttpApplication app)
            {
                timer = new Timer(new TimerCallback(SendEmail), null, 0, interval);
            }

            private void SendEmail(object obj)
            {
                lock (synclock)
                {
                    DateTime dd = DateTime.Now;
                    if (dd.Hour == 1 && dd.Minute == 30 && sent == false)
                    {
                        
                    }
                    else if (dd.Hour != 1 && dd.Minute != 30)
                    {
                        sent = false;
                    }
                }
            }
            public void Dispose()
            { }
        
    }
}