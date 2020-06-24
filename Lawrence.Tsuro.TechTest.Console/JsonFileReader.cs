using CsvHelper;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lawrence.Tsuro.TechTest.Console
{
    public static class JsonFileReader
    {
        public static List<CsvAddressesReaderDto> ReadLocalFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Invalid file path when for the local json file");
            }

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.ReadHeader();
                    var csvHeaders = csv.FieldHeaders;

                    Type type = typeof(CsvAddressesReaderDto);
                    var properties = type.GetProperties().Where(p => Attribute.IsDefined(p, typeof(RequiredAttribute)));
                    bool hasPropertyErrors = false;

                    foreach (PropertyInfo property in properties)
                    {
                        if (!csvHeaders.Contains(property.Name))
                        {
                            System.Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.WriteLine($"Could not find {property.Name} header");
                            hasPropertyErrors = true;
                        }
                    }

                    if (hasPropertyErrors)
                    {
                        throw new Exception("Failed to upload json file because it has warnings above");
                    }

                    return csv.GetRecords<CsvAddressesReaderDto>().Cast<CsvAddressesReaderDto>().ToList();
                }
            }
        }
    }
}