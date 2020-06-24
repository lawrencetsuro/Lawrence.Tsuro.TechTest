using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lawrence.Tsuro.TechTest.Entities.Contracts;

namespace Lawrence.Tsuro.TechTest.Entities
{
    public class Address : IAudit
    {
        [ Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public Guid AddressId { get; set; }

        [ Required, MaxLength(250) ]
        public string Name { get; set; }

        [ Required, MaxLength(250) ]
        public string Surname { get; set; }

        [ Required, MaxLength(250) ]
        public string Company { get; set; }

        [ Required, MaxLength(250) ]
        public string Street { get; set; }

        [ Required, MaxLength(250) ]
        public string City { get; set; }

        [ Required, MaxLength(250) ]
        public string County { get; set; }

        [ Required, DataType(DataType.PostalCode), MaxLength(250) ]
        public string Postcode { get; set; }

        [ Required, DataType(DataType.PhoneNumber), MaxLength(250) ]
        public string Phone { get; set; }

        [ Required, DataType(DataType.EmailAddress), MaxLength(250) ]
        public string Email { get; set; }

        [ Required ]
        public DateTime Updated { get; set; }
    }
}