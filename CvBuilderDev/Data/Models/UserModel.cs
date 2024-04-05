using System;
using System.ComponentModel.DataAnnotations;

namespace CvBuilderDev.Data.Models
{
	public class UserModel
	{
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

