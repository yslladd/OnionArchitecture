using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Infra.Data.EntityConfig
{
    public class TaskStatusConfig : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {
            builder.Property(x => x.Status).IsRequired();
            builder.Property(t => t.Color).HasMaxLength(7);            
        }
    }
}
