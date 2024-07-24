using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvBuilderDev.Data.Models
{
	public class RefreshToken
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Users")]
		public int UserId { get; set; }
		public required string Token { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public DateTime Expired { get; set; }


        //nav
        public virtual UserModel Users { get; set; }
    }	
}

