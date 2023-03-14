using System;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
    public interface IHeaderRepository
    {
        Task CreateOrUpdateHeader(HeaderViewModel model);
        Task<HeaderModel> GetHeader(string email);
    }
	public class HeaderRepository : IHeaderRepository
	{
        private ApplicationDbContext _db;

        public HeaderRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task CreateOrUpdateHeader(HeaderViewModel model)
        {
            var oldHeader = await _db.Header.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
            if (oldHeader != null)
            {
                oldHeader.FirstName = model.FirstName;
                oldHeader.LastName = model.LastName;
                oldHeader.Email = model.Email;
                oldHeader.Phonenumber = model.Phonenumber;
                oldHeader.City = model.City;
                oldHeader.LinkedInId = model.LinkedInId;
                oldHeader.ProfilePicture = model.ProfilePicture;
                _db.Header.Update(oldHeader);
                await _db.SaveChangesAsync();
            }
            else
            {
                var newHeader = new HeaderModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phonenumber = model.Phonenumber,
                    LinkedInId = model.LinkedInId,
                    City = model.City,
                    ProfilePicture = model.ProfilePicture
                };
                await _db.Header.AddAsync(newHeader);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<HeaderModel> GetHeader(string email)
        {
            return await _db.Header.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}

