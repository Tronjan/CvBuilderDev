using System;
using System.ComponentModel.DataAnnotations;

namespace CvBuilderDev.Data.Models
{
	public class HeaderModel
	{
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string LinkedInId { get; set; }

        public string City { get; set; }

        public string ProfilePicture { get; set; }
    }
}

