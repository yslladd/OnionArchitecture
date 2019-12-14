
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Infra.Data.EntityConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
