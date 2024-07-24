using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Utils;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CvBuilderDev.Data.Models;
using System.Security.Cryptography;
using System.Web;
using CvBuilderDev.Repositories;

namespace CvBuilderDev.Services
{
	public interface ICreateToken
	{
		string Createtoken(TokenGenerationRequestViewModel request);
        Task<RefreshTokenViewModel> CreateRefreshToken();
        Task UpdateRefreshToken(RefreshTokenViewModel refreshTokenViewModel);
    }

	public class CreateToken : ICreateToken
	{
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;
       
		public CreateToken(IConfiguration configuration, IAuthRepository authRepository)
		{
            _configuration = configuration;
            _authRepository = authRepository;
		}

        public string Createtoken(TokenGenerationRequestViewModel request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.GetValue<string>("JwtSettings:Key");
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var audience = _configuration.GetValue<string>("JwtSettings:Audience");
            var key = Encoding.UTF8.GetBytes(secret);

            var expiryMinutes = DateTime.UtcNow.AddMinutes(30);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, request.Email),
                new(JwtRegisteredClaimNames.Email, request.Email),
                new("userId", request.UserId.ToString())
            };

            var tokenPara = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = expiryMinutes,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
           };

            var token = tokenHandler.CreateToken(tokenPara);

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }

        public async Task<RefreshTokenViewModel> CreateRefreshToken()
        {
            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(8)),
                Expired = DateTime.UtcNow.AddDays(1)
            };

            return new RefreshTokenViewModel
            {
                RefreshToken = refreshToken.Token,
                Expired = refreshToken.Expired
            };
        }


        public async Task UpdateRefreshToken(RefreshTokenViewModel refreshTokenViewModel)
        {
            var newRefreshToken = new RefreshToken()
            {
                UserId = refreshTokenViewModel.UserId,
                Token = refreshTokenViewModel.RefreshToken,
                Created = DateTime.UtcNow,
                Expired = refreshTokenViewModel.Expired
            };

            await _authRepository.UpdateRefreshToken(newRefreshToken);
        }
    }
}

