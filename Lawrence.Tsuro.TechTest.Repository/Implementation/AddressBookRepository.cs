using Lawrence.Tsuro.TechTest.Entities;
using Lawrence.Tsuro.TechTest.Repository.Contracts;
using System.Collections.Generic;

namespace Lawrence.Tsuro.TechTest.Repository.Implementation
{
    public class AddressBookRepository : RepositoryBase<Address>, IAddressBookRepository
    {
        public AddressBookRepository(AppContext appContext) : base(appContext) { }

        public void Add(IEnumerable<Address> addresses)
        {
            InsertEntities(addresses);
        }

        public IEnumerable<Address> Find()
        {
            return FindEntities();
        }
    }
}