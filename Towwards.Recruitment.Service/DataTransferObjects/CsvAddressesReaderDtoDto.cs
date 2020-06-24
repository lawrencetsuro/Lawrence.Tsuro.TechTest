using System.ComponentModel.DataAnnotations;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public sealed class CsvAddressesReaderDtoDto : CsvAndJsonAddressesBaseReaderDto
    {
        [ Required, MaxLength(250) ]
        public string Street { get; set; }

        [ Required, MaxLength(250) ]
        public string City { get; set; }

        [ Required, MaxLength(250) ]
        public string County { get; set; }

        [ Required, DataType(DataType.PostalCode), MaxLength(250) ]
        public string Postcode { get; set; }
    }
}