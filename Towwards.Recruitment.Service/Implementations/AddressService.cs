using Lawrence.Tsuro.TechTest.Entities;
using Lawrence.Tsuro.TechTest.Repository.Contracts;
using Lawrence.Tsuro.TechTest.Services.Contracts;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lawrence.Tsuro.TechTest.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressBookRepository _addressRepository;

        public AddressService(IAddressBookRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void UploadAddressesToDb(IEnumerable<CsvAddressesReaderDtoDto> csvAddressesDtos)
        {
            try
            {
                if (csvAddressesDtos == null && !csvAddressesDtos.Any())
                {
                    throw new ArgumentException("Csv has been read but empty");
                }

                var addresses = new List<Address>();

                foreach (var csvAddressesDto in csvAddressesDtos)
                {
                    var address = new Address
                                  {
                                      Phone    = csvAddressesDto.Phone,
                                      Company  = csvAddressesDto.City,
                                      Email    = csvAddressesDto.Email,
                                      Name     = csvAddressesDto.Name,
                                      Surname  = csvAddressesDto.Surname,
                                      City     = csvAddressesDto.City,
                                      County   = csvAddressesDto.County,
                                      Postcode = csvAddressesDto.Postcode,
                                      Street   = csvAddressesDto.Street,
                                      Updated  = DateTime.Now
                                  };

                    addresses.Add(address);
                }

                _addressRepository.Add(addresses);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Could not upload to database", e.InnerException);
            }
        }

        public IEnumerable<AddressBookDto> FindAddressBookDtos()
        {
            try
            {
                var addresses = _addressRepository.Find();

                if (addresses != null && !addresses.Any())
                {
                    return new List<AddressBookDto>();
                }

                var addressBookDtos = MappingProfile.FromAddressesDbEntityToAddressBookDto(addresses.ToList());

                return addressBookDtos;
            }
            catch (Exception e)
            {
                throw new Exception("Could not find address book details", e.InnerException);
            }
        }

        // this part should be not be considered for production but to demonstrate that data was save to the database from the csv file...
        public IEnumerable<Address> FindAddressesForDemoPurposes()
        {
            try
            {
                return _addressRepository.Find();
            }
            catch (Exception e)
            {
                throw new Exception("Could not find address book details", e.InnerException);
            }
        }
    }
}