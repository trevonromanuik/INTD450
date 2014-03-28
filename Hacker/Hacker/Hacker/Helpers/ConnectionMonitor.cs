using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Timers;

namespace Hacker.Helpers
{
    class ConnectionMonitor
    {
        Timer checkTimer;

        public ConnectionMonitor()
        {
            checkTimer = new Timer(30 * 1000);
            checkTimer.Elapsed += new ElapsedEventHandler(checkInterwebsEvent);
            checkTimer.AutoReset = true;
        }

        public void runMonitor()
        {
            checkTimer.Enabled = true;
        }

        private static void checkInterwebsEvent(object source, ElapsedEventArgs e)
        {
            if (!checkInterwebs())
            {
                throw new PingException("No network connection detected.");
            }
        }

        public static bool checkInterwebs()
        {
            try
            {
                var reply = new Ping().Send("google.com", 1000, new byte[32], new PingOptions());
                return reply.Status == IPStatus.Success ? true : false;
            }
            catch (PingException)
            {
                return false;
            }
        }
    }
}
