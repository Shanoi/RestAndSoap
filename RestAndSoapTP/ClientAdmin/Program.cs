using ClientAdmin.AdminLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin
{
    class Program
    {

        private static string ERROR_MESSAGE = "Wrong input. Type \"help\" for the list of commands\n";

        static void Main(string[] args)
        {

            AdminCommandsClient client = new AdminCommandsClient();

            string commands = "help: Display the help\n" +
            "city <Months>: Change the duration of the cache for the cities (in months)\n" +
            "stations <Minutes> : Change the duration of the cache for the stations (in minutes)\n" +
            "exit: quit the program\n";

            Console.WriteLine("Type \"help\" for help");

            string s = "";

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

                        case "exit":
                            break;

                        default:
                            Console.WriteLine(ERROR_MESSAGE);
                            break;

                    }
                }
                else if (s.Split(' ').Length == 2)
                {
                    int x = 0;

                    if (Int32.TryParse(s.Split(' ')[1], out x))
                    {

                        switch (s.Split(' ')[0])
                        {

                            case "city":


                                Console.WriteLine(client.updateCacheDurationCitites(x));


                                break;

                            case "station":

                                Console.WriteLine(client.updateCacheDurationStations(x));

                                break;


                            default:
                                Console.WriteLine(ERROR_MESSAGE);
                                break;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong parameter, need an integer");
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
