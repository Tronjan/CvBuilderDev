using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
    public interface IHeaderRepository
    {
        Task CreateHeader(HeaderModel newHeader);
        Task<HeaderModel> GetHeader(string email);
    }
	public class HeaderRepository : IHeaderRepository
	{
        private ApplicationDbContext _db;

        public HeaderRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task CreateHeader(HeaderModel newHeader)
        {
            await _db.Header.AddAsync(newHeader);
            await _db.SaveChangesAsync();
        }
        
        public async Task<HeaderModel> GetHeader(string email)
        {
            return await _db.Header.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}

