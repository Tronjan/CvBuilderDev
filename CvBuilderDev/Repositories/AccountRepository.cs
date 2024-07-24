using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
    public interface IAccountRepository
    {
        Task<UserModel> GetUserAccountDetails(UserModel userModel);
        Task CreateUserAccount(UserDetailsModel userDetails, UserModel userModel);
        Task<UserDetailsModel> GetUserDetails(string email);
        Task<UserDetailsModel> GetUserDetailsById(int userId);
    }

    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task CreateUserAccount(UserDetailsModel userDetails, UserModel userModel)
        {
            var olduser = await _db.UserDetails.Where(x => x.Email == userDetails.Email).FirstOrDefaultAsync();

            if(olduser != null)
            {
                throw new Exception($"User with email:{userDetails.Email} already exists");
            }

            await _db.Users.AddAsync(userModel);
            await _db.SaveChangesAsync();

            userDetails.UserId = userModel.Id;
            await _db.UserDetails.AddAsync(userDetails);
            await _db.SaveChangesAsync();
           
        }

        public async Task<UserDetailsModel> GetUserDetails(string email)
        {
           var user = await _db.UserDetails.Where(x => x.Email == email).FirstOrDefaultAsync();
           if(user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return user;
            }
        }

        public async Task<UserModel> GetUserAccountDetails(UserModel userModel)
        {
            return await _db.Users.Where(x => x.Email == userModel.Email).FirstOrDefaultAsync();
        }

        public async Task<UserDetailsModel> GetUserDetailsById(int userId)
        {
            var user = await _db.UserDetails.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return user;
            }
        }
    }
}

