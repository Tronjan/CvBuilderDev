using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvBuilderDev.Data.Models
{
	public class UserDetailsModel
	{
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;


        //nav

        public virtual UserModel Users { get; set; }
    }
}

