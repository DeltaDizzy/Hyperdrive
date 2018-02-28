using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hyperdrive
{
    public class GeneralStuff
    {
        public static string ImpDriveLogFormatter(string logMessage)
        {
            return String.Format("[IMPDRIVE]: " + logMessage);
        }

        public static string HyperdriveLogFormatter(string logMessage)
        {
            return String.Format("[Hyperdrive]: " + logMessage);
        }
    }
}