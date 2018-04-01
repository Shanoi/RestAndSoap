using ClientConsoleAsync.JCDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleAsync
{
    class Program
    {
        private static string ERROR_MESSAGE = "Wrong input. Type \"help\" for the list of commands\n";

        static void Main(string[] args)
        {

            VelibsRetrieverClient client = new VelibsRetrieverClient();

            string commands = "help: Display the help\n" +
                "fidelity [Bronze | Silver | Gold]: choose the level of fidelity for the cache fidelity of the station, or display the different fidelity programs\n" +
                "cities: Display the list of the available cities\n" +
                "city <City Name>: Choose the city\n" +
                "station <Station Name> [<City Name>]: Display information about stations corresponding to the name\n" +
                "exit: quit the program\n";

            Console.WriteLine("Type \"help\" for help");

            string s = "";

            string city = "";

            List<string> fi = client.getFidelityLevels().ToList<string>();

            string fidelityLevel = "Bronze";

            while (s != "exit")
            {

                Console.WriteLine("What do you want ?");

                s = Console.ReadLine();

                if (s.Split(' ').Length == 1)
                {
                    switch (s)
                    {

                        case "help":
                            Console.WriteLine(commands);
                            break;

                        case "cities":

                            getCityData().ContinueWith(delegate { Console.WriteLine("Done"); });

                            break;

                        case "station":

                            getStationData(city, "", fidelityLevel).ContinueWith(delegate { Console.WriteLine("Done"); });

                            break;

                        case "fidelity":

                            foreach (string fid in fi)
                            {
                                Console.WriteLine(fid);
                            }

                            break;

                        case "exit":
                            break;

                        default:
                            Console.WriteLine(ERROR_MESSAGE);
                            break;

                    }
                }
                else if (s.Split(' ').Length == 2)
                {
                    switch (s.Split(' ')[0])
                    {

                        case "city":

                            city = s.Split(' ')[1].Replace('_', ' ');

                            break;

                        case "station":

                            getStationData(city, s.Split(' ')[1], fidelityLevel).ContinueWith(delegate { Console.WriteLine("Done"); });

                            break;

                        case "fidelity":

                            if (fi.Contains(s.Split(' ')[1]))
                            {
                                fidelityLevel = s.Split(' ')[1];
                            }
                            else
                            {
                                Console.WriteLine("Wrong fidelity level\n");
                            }

                            break;

                        default:
                            Console.WriteLine(ERROR_MESSAGE);
                            break;

                    }
                }
                else if (s.Split(' ').Length == 3)
                {
                    switch (s.Split(' ')[0])
                    {
                        case "station":

                            city = s.Split(' ')[2].Replace('_', ' ');

                            /*List<Station> stations = client.getListStationFromCity(city, s.Split(' ')[1]).ToList<Station>();

                            foreach (Station station in stations)
                            {
                                Console.WriteLine(stationToString(station)+ "\n");
                            }*/

                            getStationData(city, s.Split(' ')[1], fidelityLevel).ContinueWith(delegate { Console.WriteLine("Done"); });

                            break;


                        default:
                            Console.WriteLine(ERROR_MESSAGE);
                            break;

                    }
                }
                else
                {

                    Console.WriteLine("Wrong input arguments. Type \"help\" for the list of commands\n");

                }

            }


        }

        static async Task getCityData()
        {

            try
            {
                Task<List<string>> task = new VelibsRetrieverClient().getCitiesAsync();
                if (task == await Task.WhenAny(task, Task.Delay(10000000)))
                {

                    foreach (string citi in await task)
                    {
                        Console.WriteLine(citi);
                    }

                }
                else Console.WriteLine("Timed out");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static async Task getStationData(string city, string station, string fidelity)
        {

            try
            {
                Task<string> task = new VelibsRetrieverClient().getDataFromCityAsync(city.Replace('_', ' '), station.Replace('_', ' '), fidelity);
                if (task == await Task.WhenAny(task, Task.Delay(10000000)))
                {
                    Console.WriteLine(await task);
                }
                else Console.WriteLine("Timed out");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
