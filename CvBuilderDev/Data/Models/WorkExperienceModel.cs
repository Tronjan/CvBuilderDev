using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvBuilderDev.Data.Models
{
	public class WorkExperienceModel
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

        [NotMapped]
        public List<string> Description { get; set; }

        [NotMapped]
        public List<string> Tags { get; set; }
    }
}

