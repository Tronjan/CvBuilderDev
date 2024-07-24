using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;

namespace CvBuilderDev.Repositories
{
	public class WorkExperienceRepository
	{
        private ApplicationDbContext _db;

        public WorkExperienceRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<WorkExperienceModel> CreateOrUpdate(string email)
        {
            return null;
        }
    }
}

