using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    class VelibsRetriver : IVelibsRetriever
    {

        JArray jsonArrayCities;
        JArray jsonArrayStation;

        ArrayList stations;

        public string getCities()
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            jsonArrayCities = JArray.Parse(reader.ReadToEnd());

            string result = "";

            foreach (JObject item in jsonArrayCities)
            {
                result += (String)item.GetValue("name") + "\n" ;
            }

            return result;

        }

        public string getDataFromCity(string city, string station)
        {

            string data;

            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");

            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            data = reader.ReadToEnd();
            jsonArrayStation = JArray.Parse(data);

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

            string result = "";

            foreach (Station item in stations)
            {

                result += item.ToString() + "\n";

            }

            return result;

        }

    }
}
