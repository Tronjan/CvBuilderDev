using System;
using System.Threading.Tasks;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Data.Models;
using CvBuilderDev.Repositories;
using CvBuilderDev.Utils;

namespace CvBuilderDev.Services
{
    public interface IAccountService
    {
        Task<ResponseViewModel> GetLoginResponse(UserViewModel userViewModel);
        Task<bool> CreateNewUser(RegisterViewModel userDetailsViewModel);
        Task<UserDetailsViewModel> GetUserDetails(string email);
        Task<RefreshTokenViewModel> GetRefreshToken(int userId);
        Task<UserDetailsViewModel> GetUserDetailsById(int userid);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accounReposirtoy;
        private readonly ICreateToken _createToken;
        private readonly IAuthRepository _authRepository;
        public AccountService(IAccountRepository accountRepository, ICreateToken createToken, IAuthRepository authRepository)
        {
            _accounReposirtoy = accountRepository;
            _createToken = createToken;
            _authRepository = authRepository;
        }


        public async Task<UserDetailsViewModel> GetUserDetails(string email)
        {
            var user = await _accounReposirtoy.GetUserDetails(email);

            if(user == null)
            {
                throw new Exception("User details not found");
            }

            var userDetails = new UserDetailsViewModel
            {
                Email = user.Email,
                Id = user.Id
            };
            return userDetails;
        }

        public async Task<UserDetailsViewModel> GetUserDetailsById(int userid)
        {
            var user = await _accounReposirtoy.GetUserDetailsById(userid);

            if (user == null)
            {
                throw new Exception("User details not found");
            }

            var userDetails = new UserDetailsViewModel
            {
                Email = user.Email,
                Id = user.Id
            };
            return userDetails;
        }

        public async Task<bool> CreateNewUser(RegisterViewModel userDetailsViewModel)
        {
            var newUserDetails = new UserDetailsModel
            {
                FirstName = userDetailsViewModel.FirstName,
                LastName = userDetailsViewModel.LastName,
                Email = userDetailsViewModel.Email
            };

            var newUser = new UserModel
            {
                Email = userDetailsViewModel.Email,
                Password = userDetailsViewModel.Password
            };

            await _accounReposirtoy.CreateUserAccount(newUserDetails, newUser);
            var user = await _accounReposirtoy.GetUserDetails(userDetailsViewModel.Email);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ResponseViewModel> GetLoginResponse(UserViewModel userData)
        {
            var userDetails = new UserModel
            {
                Email = userData.Email,
                Password = userData.Password
            };
            var user = await _accounReposirtoy.GetUserAccountDetails(userDetails);

            var response = new ResponseViewModel();

            if (user == null || !BCrypt.Net.BCrypt.Verify(userData.Password, user.Password))
            {
                response.Response = Constants.LOGIN_FAILED;
                return response;
            }

            response.Response = Constants.LOGIN_SUCCESS;
            response.Email = user.Email;
            response.UserId = user.Id;

            var tokenGeneration = new TokenGenerationRequestViewModel()
            {
                Email = user.Email,
                UserId = user.Id
            };

            response.Jwt = _createToken.Createtoken(tokenGeneration);      
            return response;
        }

        public async Task<RefreshTokenViewModel> GetRefreshToken(int userId)
        {
            var token = await _authRepository.GetRefreshToken(userId);
            if(token == null)
            {
                throw new Exception("Token not found or Invalid Token");
            }

            var refreshToken = new RefreshTokenViewModel
            {
                RefreshToken = token.Token,
                Expired = token.Expired,
            };

            return refreshToken;
        }
    }
}

