using System;
using System.ComponentModel.DataAnnotations;

namespace CvBuilderDev.Areas.Models
{
	public class UserViewModel
    { 
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}

