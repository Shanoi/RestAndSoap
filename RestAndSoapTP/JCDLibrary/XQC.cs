using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    public partial class WcfEntryPoint
    {
        public static void Configure(ServiceConfiguration config)
        {
            config.LoadFromConfiguration(ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = @"App.config" }, ConfigurationUserLevel.None));
        }
    }

    class VelibsRetriever2 : IVelibsRetriever
    {

        private const string CITIES_KEY = "cities";

        private CacheVelibs cache = new CacheVelibs(1, 5);

        private Dictionary<string, DateTime> lastUpdateStationsGUI = new Dictionary<string, DateTime>();

        private Dictionary<string, DateTime> lastUpdateStationsConsole = new Dictionary<string, DateTime>();

        public List<string> getCities()
        {

            List<string> cities = cache.Cache[CITIES_KEY] as List<string>;

            if (cities == null)
            {

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                JArray jsonArrayCities = JArray.Parse(reader.ReadToEnd());

                cities = new List<string>();

                foreach (JObject item in jsonArrayCities)
                {
                    cities.Add((String)item.GetValue("name"));
                }

                cache.setCacheCities(CITIES_KEY, cities);

            }

            return cities;

        }

        public string getDataFromCity(string city, string station, string fidelity)
        {
            string key = city + "string";
            string data = cache.Cache[key] as string;

            if (data == null || DateTime.Now >= lastUpdateStationsConsole[city] + cache.Fidelity[fidelity])
            {

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                try
                {
                    WebResponse response = request.GetResponse();

                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    data = reader.ReadToEnd();

                    cache.setCacheStation(key, data);
                    lastUpdateStationsConsole[city] = DateTime.Now;
                }
                catch (Exception)
                {

                    return "Wrong city name";
                }

            }

            JArray jsonArrayStation = JArray.Parse(data);

            List<Station> stations = new List<Station>();

            foreach (JObject item in jsonArrayStation)
            {

                string name = (String)item.GetValue("name");
                if (name.ToUpper().Contains(station.ToUpper()))
                {
                    stations.Add(new Station((String)item.GetValue("name"),
                        (String)item.GetValue("address"),
                        (String)item.GetValue("status"),
                        (int)item.GetValue("available_bike_stands"),
                        (int)item.GetValue("available_bikes")));

                }
            }

            if (stations.Count == 0)
            {
                return "No station to display";
            }

            string result = "";

            foreach (Station item in stations)
            {

                result += item.ToString() + "\n\n";

            }

            return result;
        }

        public List<string> getFidelityLevels()
        {
            return cache.Fidelity.Keys.ToList();
        }

        public DateTime getLastUpdate(string city)
        {
            return lastUpdateStationsGUI[city];
        }

        public async Task<List<Station>> getListStationFromCity(string city, string station, string fidelity)
        {

            string key = city + "station";
            List<Station> stations = cache.Cache[key] as List<Station>;


            if (stations == null || DateTime.Now >= lastUpdateStationsGUI[city] + cache.Fidelity[fidelity])
            {

                stations = await GetListStationAsync(city);

                cache.setCacheStation(key, stations);

                lastUpdateStationsGUI[city] = DateTime.Now;

            }

            List<Station> result = new List<Station>();

            foreach (Station item in stations)
            {

                if (item.Name.ToUpper().Contains(station.ToUpper()))
                {
                    result.Add(item);

                }
            }

            return result;
        }

        private async Task<List<Station>> GetListStationAsync(string city)
        {

            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

            //WebResponse response = 
            WebResponse response = await request.GetResponseAsync();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            JArray jsonArrayStation = JArray.Parse(await reader.ReadToEndAsync());

            List<Station> sts = new List<Station>();

            foreach (JObject item in jsonArrayStation)
            {

                sts.Add(new Station((String)item.GetValue("name"),
                    (String)item.GetValue("address"),
                    (String)item.GetValue("status"),
                    (int)item.GetValue("available_bike_stands"),
                    (int)item.GetValue("available_bikes")));

            }

            return sts;

        }

    }

    class AdminCommands2 : IAdminCommands
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
