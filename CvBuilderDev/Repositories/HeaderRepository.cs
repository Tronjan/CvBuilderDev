using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
    public interface IHeaderRepository
    {
        Task<HeaderModel> GetHeader(string email);
    }
	public class HeaderRepository : IHeaderRepository
	{
        private ApplicationDbContext _db;

        public HeaderRepository(ApplicationDbContext context)
        {
            _db = context;
        }


        public async Task<HeaderModel> GetHeader(string email)
        {
            return await _db.Header.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}

