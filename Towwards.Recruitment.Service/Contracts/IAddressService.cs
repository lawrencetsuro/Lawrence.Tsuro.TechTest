using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using System.Collections.Generic;
using Lawrence.Tsuro.TechTest.Entities;

namespace Lawrence.Tsuro.TechTest.Services.Contracts
{
    public interface IAddressService
    {
        void UploadAddressesToDb(IEnumerable<CsvAddressesReaderDtoDto> csvAddressBookDtos);

        IEnumerable<AddressBookDto> FindAddressBookDtos();

        // this part should be not be considered for production but to demonstrate that data was save to the database from the csv file...
        IEnumerable<Address> FindAddressesForDemoPurposes();
    }
}