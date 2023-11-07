using System;
using System.ComponentModel.DataAnnotations;
using CvBuilderDev.Data.Models;

namespace CvBuilderDev.Areas.Models
{
	public class WorkExperienceViewModel
	{
        public int Id { get; set; }

        public List<WorkExperienceModel> WorkExperienceModel { get; set; }
    }
}
