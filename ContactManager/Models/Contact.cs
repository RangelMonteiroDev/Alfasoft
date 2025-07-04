using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ID { get; set; }

    [Required, MinLength(5)]
    public string Name { get; set; }

    [Required, RegularExpression(@"^\d{9}$")]
    public string ContactNumber { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    public bool IsDeleted { get; set; } = false;
    }
}