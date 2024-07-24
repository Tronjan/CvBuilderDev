using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvBuilderDev.Areas.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName {get; set;}

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

