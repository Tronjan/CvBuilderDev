using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
	public interface IAccountRepository
	{
		Task<UserModel> GetUserAccountDetails(UserModel userModel);
	}
	public class AccountRepository : IAccountRepository
	{
        private ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<UserModel> GetUserAccountDetails(UserModel userModel)
        {
            return await _db.User.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefaultAsync();
        }
    }
}

