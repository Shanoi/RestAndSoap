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

        JArray jsonArrayCities;
        JArray jsonArrayStation;

        public List<string> getCities()
        {

            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            jsonArrayCities = JArray.Parse(reader.ReadToEnd());

            List<string> result = new List<string>();

            foreach (JObject item in jsonArrayCities)
            {
                result.Add((String)item.GetValue("name"));
            }
           
            return result;

        }

        public string getDataFromCityString(string city, string station)
        {

            ObjectCache cache = MemoryCache.Default;
            string data = cache[city] as string;


            if (data == null)
            {

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0);

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

                    cache.Set(city, data, policy);

                }
                catch (Exception)
                {

                    return "Wrong city name";
                }

            }

            jsonArrayStation = JArray.Parse(data);

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

            return result;

        }

        public ArrayList getDataFromCityStation(string city, string station)
        {
            ObjectCache cache = MemoryCache.Default;
            string data = cache[city] as string;


            if (data == null)
            {

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0);

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                data = reader.ReadToEnd();

                cache.Set(city, data, policy);

            }

            jsonArrayStation = JArray.Parse(data);

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

            return stations;

        }

        async public Task<string> getDataFromCityAsync(string city, string station)
        {

            ObjectCache cache = MemoryCache.Default;
            string data = cache[city] as string;


            if (data == null)
            {

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10.0);

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

                try
                {
                    WebResponse response = await request.GetResponseAsync();

                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    data = reader.ReadToEnd();

                    cache.Set(city, data, policy);

                }
                catch (Exception)
                {

                    return "Wrong city name";
                }

            }

            jsonArrayStation = JArray.Parse(data);

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

            return result;

        }


    }
}
