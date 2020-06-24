using Lawrence.Tsuro.TechTest.Services.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lawrence.Tsuro.TechTest.Console
{
    public class Program : DisplayInfoOnConsole
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    System.Console.WindowWidth     = System.Console.LargestWindowWidth;
                    System.Console.WindowHeight    = System.Console.LargestWindowHeight;
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine("Demo technical test");
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Select from the following options");
                    System.Console.WriteLine("...........................................................");
                    System.Console
                          .WriteLine("1: Process cvs file and save it to a local database that you possible and initially migrated. Console will mirror the database table");
                    System.Console
                          .WriteLine("2: Process database records and  convert to a json with payload on console");
                    System.Console
                          .WriteLine("3: Process and export csv records directly - and convert to a json with payload to /consoledata/export-addresses.json");
                    System.Console
                          .WriteLine("4: Process and export json records directly - and convert to a csv result set to /consoledata/export-addresses.json");

                    System.Console.ForegroundColor = ConsoleColor.White;
                    var userInput = System.Console.ReadLine();

                    if (int.TryParse(userInput, out var selection))
                    {
                        var addressService = BuildServiceProvider.GetService<IAddressService>();

                        switch (selection)
                        {
                            case (int) UserInput.CvsToDb:
                                ProcessCvsAndSaveToDbAndConsoleDisplayResults(addressService);
                                break;

                            case (int) UserInput.DbToJson:
                                ConvertDbRecordsToJsonAndConsoleDisplayResults(addressService);
                                break;

                            case (int) UserInput.CsvToJson:
                                ExportCsvToJsonInFileInConsoleDataDirectory(addressService);
                                break;

                            case (int) UserInput.JsonToCsv:
                                ExportJsonToCsvInFileConsoleDataDirectory(addressService);
                                break;

                            default:
                                System.Console.WriteLine("Enter values between 1-4 from the options above");
                                System.Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid user input.Enter values between 1-4 from the options above");
                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine(e.Message);
                    ClearScreenAfterInteraction("Press any key to proceed");
                }
            }
        }
    }
}