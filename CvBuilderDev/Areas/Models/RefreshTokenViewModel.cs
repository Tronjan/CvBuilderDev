using System;
using System.ComponentModel.DataAnnotations;

namespace CvBuilderDev.Areas.Models
{
	public class RefreshTokenViewModel
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public string RefreshToken { get; set; }
		public DateTime Expired { get; set; }
	}
}

