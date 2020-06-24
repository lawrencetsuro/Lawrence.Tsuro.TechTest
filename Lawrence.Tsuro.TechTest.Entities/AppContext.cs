using Microsoft.EntityFrameworkCore;

namespace Lawrence.Tsuro.TechTest.Entities
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // todo I acknowledge that this part smells and should be read from the config file
            options.UseSqlServer(@"Server = .; Database = LawrenceTsuro.TechTest; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        public DbSet<Address> Addresses { get; set; }
    }
}