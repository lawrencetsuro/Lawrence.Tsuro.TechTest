using System.Collections.Generic;

namespace Lawrence.Tsuro.TechTest.Repository.Contracts
{
    // todo - future development would be to make some repositories generic if not functionality doesn't have to be isolated
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindEntities();

        void InsertEntities(IEnumerable<T> entities);
    }
}