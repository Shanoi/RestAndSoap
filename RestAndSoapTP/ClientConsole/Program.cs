﻿using ClientConsole.JCDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {

        private static string ERROR_MESSAGE = "Wrong input. Type \"help\" for the list of commands\n";

        static void Main(string[] args)
        {
            VelibsRetrieverClient client = new VelibsRetrieverClient();

            string commands = "help: Display the help\n" +
            "cities: Display the list of the available cities\n" +
            "city <City Name>: Choose the city\n" +
            "station <Station Name> [<City Name>]: Display information about stations corresponding to the name\n" +
            "exit: quit the program\n";

            Console.WriteLine("Type \"help\" for help");

            string s = "";

            string city = "";

            while (s != "exit")
            {
                s = Console.ReadLine();

                if (s.Split(' ').Length == 1)
                {
                    switch (s)
                    {

                        case "help":
                            Console.WriteLine(commands);
                            break;

                        case "cities":


                            Console.WriteLine(client.getCities() + "\n");
                            break;

                        case "station":

                            Console.WriteLine(client.getDataFromCity(city, ""));

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

                            city = s.Split(' ')[1];

                            break;

                        case "station":

                            Console.WriteLine(client.getDataFromCity(city, s.Split(' ')[1]));

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

                            city = s.Split(' ')[2];

                            client.getListStationFromCity(city, s.Split(' ')[1]);

                            Console.WriteLine(client.getDataFromCity(city, s.Split(' ')[1]));

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
