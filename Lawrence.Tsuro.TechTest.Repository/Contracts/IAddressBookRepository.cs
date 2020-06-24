using Lawrence.Tsuro.TechTest.Entities;
using System.Collections.Generic;

namespace Lawrence.Tsuro.TechTest.Repository.Contracts
{
    public interface IAddressBookRepository
    {
        void Add(IEnumerable<Address> addresses);

        IEnumerable<Address> Find();
    }
}