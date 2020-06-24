using System.ComponentModel.DataAnnotations;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public sealed class AddressBookDto
    {
        [ Required, MaxLength(250) ]
        public string Name { get; set; }

        [ Required, MaxLength(250) ]
        public string Surname { get; set; }

        [ Required, MaxLength(250) ]
        public string Company { get; set; }

        [ Required, DataType(DataType.PhoneNumber) ]
        public string Phone { get; set; }

        [ Required, DataType(DataType.EmailAddress) ]
        public string Email { get; set; }

        [ Required ]
        public AddressDto AddressDto { get; set; }
    }
}