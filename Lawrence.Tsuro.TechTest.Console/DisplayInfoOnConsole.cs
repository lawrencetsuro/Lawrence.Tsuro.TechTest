using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ConsoleTables;
using Lawrence.Tsuro.TechTest.Repository.Contracts;
using Lawrence.Tsuro.TechTest.Repository.Implementation;
using Lawrence.Tsuro.TechTest.Services;
using Lawrence.Tsuro.TechTest.Services.Contracts;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using Lawrence.Tsuro.TechTest.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Lawrence.Tsuro.TechTest.Console
{
    public class DisplayInfoOnConsole
    {
        protected const string CsvFilePathImport  = "../../../consoledata/import-addresses.csv";
        protected const string JsonFilePathImport = "../../../consoledata/import-addresses.json";
        protected const string JsonFilePathExport = "../../../consoledata/export-addresses.json";
        protected const string CsvFilePathExport  = "../../../consoledata/export-addresses.csv";

        protected enum UserInput
        {
            CvsToDb   = 1,
            DbToJson  = 2,
            CsvToJson = 3,
            JsonToCsv = 4
        }

        private static JsonSerializerOptions _jsonSerializerOptions { get; set; } = new JsonSerializerOptions
                                                                                    {
                                                                                        WriteIndented = true,
                                                                                        PropertyNameCaseInsensitive =
                                                                                            false,
                                                                                        PropertyNamingPolicy =
                                                                                            JsonNamingPolicy.CamelCase
                                                                                    };

        protected static ServiceProvider BuildServiceProvider =>
            new ServiceCollection()
               .AddSingleton<IAddressService, AddressService>()
               .AddSingleton<Entities.AppContext>()
               .AddSingleton<IAddressBookRepository, AddressBookRepository>()
               .BuildServiceProvider();

        protected static void ProcessCvsAndSaveToDbAndConsoleDisplayResults(IAddressService addressService)
        {
            System.Console.WriteLine("Twiggle your fingures whilst this is working at the back...");

            var csvRecords = CsvFileReader.Read(CsvFilePathImport);

            CustomValidator.ValidateJsonCsvAddressesReaderDtos(csvRecords);

            addressService.UploadAddressesToDb(csvRecords);

            var table = new ConsoleTable("AddressId  ", "Name", "Surname", "Company", "Street", "City",
                                         "County ", "Postcode", "Phone ", "Email", "Updated  ");

            var rawEntityDataStraightFromContext = addressService.FindAddressesForDemoPurposes();

            foreach (var data in rawEntityDataStraightFromContext)
            {
                table.AddRow(data.AddressId, data.Name, data.Surname, data.Company, data.Street,
                             data.City, data.County, data.Postcode, data.Phone, data.Email, data.Updated);
            }

            table.Configure(o => o.NumberAlignment = Alignment.Left);
            table.Write();

            ClearScreenAfterInteraction("There you go! You do not have to query your database. Press any key to clear screen and use other options...");
        }

        protected static void ClearScreenAfterInteraction(string consoleMsg)
        {
            System.Console.WriteLine(consoleMsg);
            System.Console.ReadKey();
            System.Console.Clear();
        }

        protected static void ConvertDbRecordsToJsonAndConsoleDisplayResults(IAddressService addressService)
        {
            var addressBookDtos = addressService.FindAddressBookDtos();

            var jsonString = JsonSerializer.Serialize(addressBookDtos, _jsonSerializerOptions);

            System.Console.WriteLine(jsonString);

            ClearScreenAfterInteraction("There you go! Here is your json payload. Press any key to clear screen and use other options...");
        }

        protected static void ExportCsvToJsonInFileInConsoleDataDirectory(IAddressService addressService)
        {
            var csvRecords = CsvFileReader.Read(CsvFilePathImport);

            CustomValidator.ValidateJsonCsvAddressesReaderDtos(csvRecords);

            var addressBookDtos = MappingProfile.FromCsvAddressesToAddressBookDto(csvRecords);

            var jsonRecords = JsonSerializer.Serialize(addressBookDtos, _jsonSerializerOptions);

            File.WriteAllText(JsonFilePathExport, jsonRecords);

            ClearScreenAfterInteraction("Exported cvs to json file directory located @consoledata/export-addresses.json on. Press any key to clear screen and use other options...");
        }

        protected static void ExportJsonToCsvInFileConsoleDataDirectory(IAddressService addressService)
        {
            var fileContents = File.ReadAllText(JsonFilePathImport);

            var jsonRecords =
                JsonSerializer.Deserialize<List<JsonAddressesReaderDtoDto>>(fileContents, _jsonSerializerOptions);

            CustomValidator.ValidateJsonCsvAddressesReaderDtos(jsonRecords);

            var mapper = MappingProfile.FromJsonAddressesToCsvAddressesDto(jsonRecords);

            using (var writer = new StreamWriter(CsvFilePathExport))
            {
                using (var csv = new CsvHelper.CsvWriter(writer))
                {
                    csv.WriteRecords(mapper);
                }
            }

            ClearScreenAfterInteraction("Exported json to csv file directory located @consoledata/export-addresses.csv on. Press any key to clear screen and use other options...");
        }
    }
}