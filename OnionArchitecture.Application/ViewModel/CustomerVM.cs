using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnionArchitecture.Application.ViewModel
{
    public class CustomerVM
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
