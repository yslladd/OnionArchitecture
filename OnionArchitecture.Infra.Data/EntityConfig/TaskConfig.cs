using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Infra.Data.EntityConfig
{
    public class TaskConfig : IEntityTypeConfiguration<Task> 
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(t => t.Title).IsRequired();
            builder.Property(t => t.Title).HasMaxLength(250);            
        }
    }
}
