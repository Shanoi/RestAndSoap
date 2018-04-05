using ClientConsole.JCDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {

        private static string ERROR_MESSAGE = "Wrong input. Type \"help\" for the list of commands\n";

        static void Main(string[] args)
        {

            VelibsServiceCallbackSink objsink = new VelibsServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);

            JCDLibrary.VelibsRetrieverClient objClient = new JCDLibrary.VelibsRetrieverClient(iCntxt);
            objClient.SubscribeRetrievedEvent();
            objClient.SubscribeRetrieveFinishedEvent();
            
            string commands = "help: Display the help\n" +
                "sub <duration> <Station name> <City Name> : Subscribe to a station with a duration in seconds (May have unexpected behaviour :))\n" +
                "cities: Display the list of the available cities\n" +
                "city <City Name>: Choose the city\n" +
                "station <Station Name> [<City Name>]: Display information about stations corresponding to the name\n" +
                "exit: quit the program\n";

            Console.WriteLine("Type \"help\" for help");

            string s = "";

            string city = "";
   
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

                            /*List<string> cities = client.getCities().ToList<string>();
                            
                            foreach (string citi in cities)
                            {
                                Console.WriteLine(citi);
                            }*/

                            objClient.getCities();

                            break;

                        case "station":

                            //Console.WriteLine(client.getDataFromCity(city, "", fidelityLevel));
                            objClient.getDataFromCity(city, "", fidelityLevel);
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

                            //Console.WriteLine(client.getDataFromCity(city, s.Split(' ')[1].Replace('_', ' '), fidelityLevel));

                            objClient.getDataFromCity(city, s.Split(' ')[1].Replace('_', ' '), fidelityLevel);

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

                            //Console.WriteLine(client.getDataFromCity(city, s.Split(' ')[1].Replace('_', ' '), fidelityLevel));
                            objClient.getDataFromCity(city, s.Split(' ')[1].Replace('_', ' '), fidelityLevel);
                            break;
                   
                        default:
                            Console.WriteLine(ERROR_MESSAGE);
                            break;

                    }
                }
                else if (s.Split(' ').Length == 4)
                {
                    switch (s.Split(' ')[0])
                    {
                        
                        case "sub":

                            city = s.Split(' ')[3].Replace('_', ' ');

                            objClient.fetch(Int32.Parse(s.Split(' ')[1]), city, s.Split(' ')[2].Replace('_', ' '));

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

    }
}
