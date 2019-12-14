using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Entities
{
    public class TaskStatus
    {
        public Guid TaskStatusId { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }

    }
}
