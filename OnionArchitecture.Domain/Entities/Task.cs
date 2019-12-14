using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool isActive { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual TaskStatus TaskStatus { get; set; }

    }
}
