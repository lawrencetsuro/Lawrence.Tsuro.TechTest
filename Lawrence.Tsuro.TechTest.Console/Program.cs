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
                    System.Console.WriteLine("Demo technical test: Make that you read the readme.md");
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Select from the following options");
                    System.Console.WriteLine("...........................................................");
                    System.Console
                          .WriteLine("1: Export data from cvs file and save it to a local database initially migrated. Console will mirror the database table");
                    System.Console
                          .WriteLine("2: Export database records to json with payload on console");
                    System.Console
                          .WriteLine("3: Export data from import csv to json with payload saved on /consoledata/export-addresses.json");
                    System.Console
                          .WriteLine("4: Export data from import json to csv with payload saved on  /consoledata/export-addresses.csv");

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
                                throw new Exception("Enter values between 1-4 from the options above");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid user input.Enter values between 1-4 from the options above");
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