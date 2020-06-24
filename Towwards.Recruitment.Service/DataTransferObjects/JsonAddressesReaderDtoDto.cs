using System.ComponentModel.DataAnnotations;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public sealed class JsonAddressesReaderDtoDto : CsvAndJsonAddressesBaseReaderDto
    {
        [ Required ]
        public AddressDto AddressDto { get; set; }
    }
}