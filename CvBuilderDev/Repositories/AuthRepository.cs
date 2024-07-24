using System;
using CvBuilderDev.Data;
using CvBuilderDev.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CvBuilderDev.Repositories
{
    public interface IAuthRepository
    {
        Task UpdateRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetRefreshToken(int userId);
    }
    public class AuthRepository : IAuthRepository
	{
        private ApplicationDbContext _db;
        public AuthRepository(ApplicationDbContext context)
		{
            _db = context;
        }

        public async Task UpdateRefreshToken(RefreshToken refreshToken)
        {
            var updateToken = await _db.RefreshToken.Where(x => x.UserId == refreshToken.UserId).FirstOrDefaultAsync();
            if (updateToken != null)
            {
                updateToken.Token = refreshToken.Token;
                updateToken.Expired = refreshToken.Expired;
                updateToken.Created = refreshToken.Created;
                _db.RefreshToken.Update(updateToken);
                await _db.SaveChangesAsync();
                
            }
            else if(updateToken == null)
            {
                await _db.RefreshToken.AddAsync(refreshToken);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<RefreshToken> GetRefreshToken(int userId)
        {
            var token = await _db.RefreshToken.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if(token == null)
            {
                throw new Exception("Token not found or invalid");
            }

            return token;
        }
    }
}

