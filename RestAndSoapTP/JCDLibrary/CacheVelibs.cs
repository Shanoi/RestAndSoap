using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    class CacheVelibs
    {

        static int nbMonths;
        static int nbMinutes;

        private Dictionary<string, System.TimeSpan> fidelity;

        ObjectCache cache;

        public CacheVelibs(int nbMonths, int nbMinutes)
        {
            this.NbMonths = nbMonths;
            this.NbMinutes = nbMinutes;
            cache = MemoryCache.Default;
            fidelity = new Dictionary<string, TimeSpan>();
            fidelity["Bronze"] = new TimeSpan(0, 0, nbMinutes, 0);
            fidelity["Silver"] = new TimeSpan(0, 0, nbMinutes / 2, 0);
            fidelity["Gold"] = new TimeSpan(0, 0, 1, 0);
        }

        public CacheVelibs() { }

        public int NbMonths { get => nbMonths; set => nbMonths = value; }
        public int NbMinutes { get => nbMinutes; set => nbMinutes = value; }
        public ObjectCache Cache { get => cache; set => cache = value; }
        public Dictionary<string, TimeSpan> Fidelity { get => fidelity; set => fidelity = value; }

        public void setCacheCities(string key, List<string> cities)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMonths(nbMonths);
            cache.Set(key, cities, policy);

        }

        public void setCacheStation(string key, string data)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(nbMinutes);
            cache.Set(key, data, policy);

        }

        public void setCacheStation(string key, List<Station> stations)
        {

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(nbMinutes);
            cache.Set(key, stations, policy);

        }

    }
}
