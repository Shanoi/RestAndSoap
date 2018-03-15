using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    class VelibsRetriever : IVelibsRetriever
    {

        private const string CITIES_KEY = "cities";

        private CacheVelibs cache = new CacheVelibs(1, 1);

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

        public async Task<List<string>> getCitiesAsync()
        {

            return await Task.Factory.StartNew(() =>
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
            });

        }

        public string getDataFromCity(string city, string station)
        {
            string key = city + "string";
            string data = cache.Cache[key] as string;


            if (data == null)
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

                }
                catch (Exception)
                {

                    return "Wrong city name";
                }

            }

            JArray jsonArrayStation = JArray.Parse(data);

            ArrayList stations = new ArrayList();

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

            result += "Cache --- " + cache.NbMinutes + " ---- " + cache.NbMonths;

            return result;
        }

        public async Task<string> getDataFromCityAsync(string city, string station)
        {

            return await Task.Factory.StartNew(() =>
            {
                string key = city + "string";
                string data = cache.Cache[key] as string;


                if (data == null)
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

                    }
                    catch (Exception)
                    {

                        return "Wrong city name";
                    }

                }

                JArray jsonArrayStation = JArray.Parse(data);

                ArrayList stations = new ArrayList();

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

                result += "Cache --- " + cache.NbMinutes + " ---- " + cache.NbMonths;

                return result;
            });

        }

        public List<Station> getListStationFromCity(string city, string station)
        {

            string key = city + "station";
            List<Station> stations = cache.Cache[key] as List<Station>;


            if (stations == null)
            {

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                JArray jsonArrayStation = JArray.Parse(reader.ReadToEnd());

                stations = new List<Station>();

                foreach (JObject item in jsonArrayStation)
                {

                    stations.Add(new Station((String)item.GetValue("name"),
                        (String)item.GetValue("address"),
                        (String)item.GetValue("status"),
                        (int)item.GetValue("available_bike_stands"),
                        (int)item.GetValue("available_bikes")));

                }

                cache.setCacheStation(key, stations);

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

        public async Task<List<Station>> getListStationFromCityAsync(string city, string station)
        {

            return await Task.Factory.StartNew(() =>
            {

                string key = city + "station";
                List<Station> stations = cache.Cache[key] as List<Station>;


                if (stations == null)
                {

                    WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                    WebResponse response = request.GetResponse();

                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    JArray jsonArrayStation = JArray.Parse(reader.ReadToEnd());

                    stations = new List<Station>();

                    foreach (JObject item in jsonArrayStation)
                    {

                        stations.Add(new Station((String)item.GetValue("name"),
                            (String)item.GetValue("address"),
                            (String)item.GetValue("status"),
                            (int)item.GetValue("available_bike_stands"),
                            (int)item.GetValue("available_bikes")));

                    }

                    cache.setCacheStation(key, stations);

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
            });

        }

    }
}
