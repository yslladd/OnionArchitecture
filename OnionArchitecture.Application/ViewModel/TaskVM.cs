using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnionArchitecture.Application.ViewModel
{
    public class TaskVM
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool isActive { get; set; }

        public Guid CustomerId { get; set; }        

    }
}
