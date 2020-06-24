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
    public static class CsvFileReader
    {
        public static List<CsvAddressesReaderDtoDto> Read(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Invalid .csv file path");
            }

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.ReadHeader();
                    var csvHeaders = csv.FieldHeaders;

                    var type = typeof(CsvAddressesReaderDtoDto);
                    var properties =
                        type.GetProperties().Where(p => Attribute.IsDefined(p, typeof(RequiredAttribute)));
                    var hasPropertyErrors = false;


                    foreach (var property in properties)
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
                        throw new Exception("Failed to upload cvs file because it has warnings above");
                    }

                    return csv.GetRecords<CsvAddressesReaderDtoDto>()
                              .ToList();
                }
            }
        }
    }
}