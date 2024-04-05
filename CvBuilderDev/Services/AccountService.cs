using System;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Data.Models;
using CvBuilderDev.Repositories;

namespace CvBuilderDev.Services
{
	public interface IAccountService
	{
		Task<bool> GetLoginResponse(UserViewModel userViewModel); 
	}

	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accounReposirtoy;
		public AccountService(IAccountRepository accountRepository)
		{
			_accounReposirtoy = accountRepository;
		}

        public async Task<bool> GetLoginResponse(UserViewModel userData)
        {
			var userDetails = new UserModel
			{
				Email = userData.Email,
				Password = userData.Password
			};
			var user = await _accounReposirtoy.GetUserAccountDetails(userDetails);
			if(user == null)
			{
				return false;
			}

			return true;
        }
    }
}

