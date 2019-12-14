using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public bool isActive { get; set; }

        public virtual IEnumerable<Task> Tasks { get; set; }

        public bool IsOldCustomer(Customer customer)
        {
            return customer.isActive && DateTime.Now.Year - customer.CreateDate.Year >= 3;
        }

    }
}
