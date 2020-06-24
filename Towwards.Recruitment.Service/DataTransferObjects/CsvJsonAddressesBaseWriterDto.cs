using System;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public class CsvJsonAddressesBaseWriterDto
    {
        public Guid   AddressId { get; set; }
        public string Name      { get; set; }
        public string Surname   { get; set; }
        public string Company   { get; set; }
        public string Street    { get; set; }
        public string City      { get; set; }
        public string County    { get; set; }
        public string Postcode  { get; set; }
        public string Phone     { get; set; }
        public string Email     { get; set; }
    }
}