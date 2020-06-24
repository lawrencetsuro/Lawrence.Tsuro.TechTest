using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public class CsvAndJsonAddressesBaseReaderDto
    {
        [ Required, MaxLength(250) ]
        public string Name { get; set; }

        [ Required, MaxLength(250), DataMember(Name = "last_name") ]
        public string Surname { get; set; }

        [ Required, MaxLength(250), DataMember(Name = "company_name") ]
        public string Company { get; set; }

        [ Required, DataType(DataType.PhoneNumber), MaxLength(250) ]
        public string Phone { get; set; }

        [ Required, DataType(DataType.EmailAddress), MaxLength(250) ]
        public string Email { get; set; }
    }
}