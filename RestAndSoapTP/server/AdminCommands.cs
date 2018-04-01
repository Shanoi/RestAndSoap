using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    class AdminCommands : IAdminCommands
    {
        public string updateCacheDurationCitites(int nbMonths)
        {
            CacheVelibs cache = new CacheVelibs();
            cache.NbMonths = nbMonths;
            return "The city's cache is kept for " + nbMonths + " months now\n";
        }

        public string updateCacheDurationStations(int nbMinutes)
        {
            CacheVelibs cache = new CacheVelibs();
            cache.NbMinutes = nbMinutes;
            return "The stations' cache is kept for " + nbMinutes + " minutes now\n";
        }
    }
}
