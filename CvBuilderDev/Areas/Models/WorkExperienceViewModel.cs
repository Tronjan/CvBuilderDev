using System;
using System.ComponentModel.DataAnnotations;

namespace CvBuilderDev.Areas.Models
{
	public class WorkExperienceViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string Title { get; set; }

        [Required]
		[MaxLength(20)]
        public string Company { get; set; }

        [Required]
        public DateTime DateOfJoin { get; set; }

		public DateTime DateOfRelease { get; set; }

		[Required]
		public string Location { get; set; }

		public List<string> Description { get; set; }

		public List<string> Tags { get; set; }
	}
}

