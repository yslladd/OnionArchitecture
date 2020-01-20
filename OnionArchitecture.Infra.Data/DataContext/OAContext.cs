using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Infra.Data.EntityConfig;
using System;
using System.Linq;

namespace OnionArchitecture.Infra.Data.DataContext
{
    public class OAContext : DbContext
    {
        public OAContext(DbContextOptions<OAContext> options)
            : base(options)
        {
        }       

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //get all configuration from a exerternal class 
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new TaskStatusConfig());


            //1 to N (Customer To Tasks)
            modelBuilder.Entity<Task>()
                .HasOne(p => p.Customer)
                .WithMany(b => b.Tasks)
                .HasForeignKey(p => p.CustomerId)
                .HasConstraintName("ForeignKey_Task_Customer");

            //1 to 1 (Task To TaskStatus)
            modelBuilder.Entity<Task>()
                .HasOne(p => p.TaskStatus)
                .WithOne(b => b.Task)
                .HasForeignKey<TaskStatus>(x => x.TaskId);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDate") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Property("CreateDate").IsModified = false;
                        break;
                    case EntityState.Added:
                        entry.Property("CreateDate").CurrentValue = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}

