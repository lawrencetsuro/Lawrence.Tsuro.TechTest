using Lawrence.Tsuro.TechTest.Entities;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace Lawrence.Tsuro.TechTest.Services
{
    public class MappingProfile
    {
        public static List<AddressBookDto> FromAddressesDbEntityToAddressBookDto(List<Address> addresses)
        {
            var addressBookDtos = new List<AddressBookDto>();

            foreach (var address in addresses)
            {
                var addressBookDto = new AddressBookDto
                                     {
                                         Company = address.Company,
                                         Email   = address.Email,
                                         Name    = address.Name,
                                         Surname = address.Surname,
                                         Phone   = address.Phone,
                                         AddressDto = new AddressDto
                                                      {
                                                          AddressId = address.AddressId,
                                                          City      = address.City,
                                                          County    = address.County,
                                                          Postcode  = address.Postcode,
                                                          Street    = address.Street,
                                                          Updated   = address.Updated
                                                      }
                                     };

                addressBookDtos.Add(addressBookDto);
            }

            return addressBookDtos;
        }

        //public static List<JsonAddressesWriterDto> FromJsonAddressesToCsvAddressesDto(List<AddressBookDto> addressBookDtos, List<JsonAddressesReaderDtoDto> jsonAddressesReaderDto)
        //{
        //    var jsonAddressesWriterDtos = new List<JsonAddressesWriterDto>();

        //    foreach (var address in addressBookDtos)
        //    {
        //        var jsonAddressesWriterDto = new JsonAddressesWriterDto
        //        {
        //            Company = address.Company,
        //            Email = address.Email,
        //            Name = address.Name,
        //            Surname = address.Surname,
        //            Phone = address.Phone,
        //            AddressId = address.AddressDto.AddressId,
        //            City = address.AddressDto.City,
        //            County = address.AddressDto.County,
        //            Postcode = address.AddressDto.Postcode,
        //            Street = address.AddressDto.Street
        //        };

        //        jsonAddressesWriterDtos.Add(jsonAddressesWriterDto);
        //    }

        //    return jsonAddressesWriterDtos;
        //}

        public static List<JsonAddressesWriterDto> FromJsonAddressesToCsvAddressesDto(
            List<JsonAddressesReaderDtoDto> addressBookDtos)
        {
            var jsonAddressesWriterDtos = new List<JsonAddressesWriterDto>();

            foreach (var address in addressBookDtos)
            {
                var jsonAddressesWriterDto = new JsonAddressesWriterDto
                                             {
                                                 Company   = address.Company,
                                                 Email     = address.Email,
                                                 Name      = address.Name,
                                                 Surname   = address.Surname,
                                                 Phone     = address.Phone,
                                                 AddressId = address.AddressDto.AddressId,
                                                 City      = address.AddressDto.City,
                                                 County    = address.AddressDto.County,
                                                 Postcode  = address.AddressDto.Postcode,
                                                 Street    = address.AddressDto.Street
                                             };

                jsonAddressesWriterDtos.Add(jsonAddressesWriterDto);
            }

            return jsonAddressesWriterDtos;
        }

        public static List<AddressBookDto> FromCsvAddressesToAddressBookDto(
            List<CsvAddressesReaderDtoDto> csvAddressesDto)
        {
            var addressBookDtos = new List<AddressBookDto>();

            foreach (var address in csvAddressesDto)
            {
                var addressBookDto = new AddressBookDto
                                     {
                                         Company = address.Company,
                                         Email   = address.Email,
                                         Name    = address.Name,
                                         Surname = address.Surname,
                                         Phone   = address.Phone,
                                         AddressDto = new AddressDto
                                                      {
                                                          AddressId = Guid.NewGuid(),
                                                          City      = address.City,
                                                          County    = address.County,
                                                          Postcode  = address.Postcode,
                                                          Street    = address.Street,
                                                          Updated   = DateTime.Now
                                                      }
                                     };

                addressBookDtos.Add(addressBookDto);
            }

            return addressBookDtos;
        }
    }
}