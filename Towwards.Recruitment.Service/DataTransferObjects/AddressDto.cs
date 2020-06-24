using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lawrence.Tsuro.TechTest.Services.DataTransferObjects
{
    public sealed class AddressDto
    {
        public Guid AddressId { get; set; }

        [ Required, MaxLength(250) ]
        public string Street { get; set; }

        [ Required, MaxLength(250) ]
        public string City { get; set; }

        [ Required, MaxLength(250) ]
        public string County { get; set; }

        [ Required, MaxLength(250) ]
        public string Postcode { get; set; }

        [ NotMapped ]
        public DateTime Updated { get; set; }
    }
}