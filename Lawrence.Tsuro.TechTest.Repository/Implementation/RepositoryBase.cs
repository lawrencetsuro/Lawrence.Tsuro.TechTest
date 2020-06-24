using Lawrence.Tsuro.TechTest.Entities;
using Lawrence.Tsuro.TechTest.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Lawrence.Tsuro.TechTest.Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppContext _appContext { get; set; }

        public RepositoryBase(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<T> FindEntities()
        {
            return _appContext.Set<T>().AsEnumerable();
        }

        public void InsertEntities(IEnumerable<T> entities)
        {
            _appContext.Set<T>().AddRange(entities);

            _appContext.SaveChanges();
        }
    }
}