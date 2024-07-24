using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvBuilderDev.Data.Models
{
    public class WorkExperienceModel
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Users")]
        public int userId { get; set; }

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

        [MaxLength(30)]
        public string Description1 { get; set; }

        [MaxLength(30)]
        public string Description2 { get; set; }

        [MaxLength(10)]
        public string Tag1 { get; set; }

        [MaxLength(10)]
        public string Tag2 { get; set; }

        [MaxLength(10)]
        public string Tag3 { get; set; }

        [MaxLength(10)]
        public string Tag4 { get; set; }


        // nav

        public virtual UserModel Users { get; set; }

    }
}

