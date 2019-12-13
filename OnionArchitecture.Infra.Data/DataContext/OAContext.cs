using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Infra.Data.DataContext
{
    public class OAContext : DbContext
    {
        public OAContext(DbContextOptions<OAContext> options)
        : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

    }
}

