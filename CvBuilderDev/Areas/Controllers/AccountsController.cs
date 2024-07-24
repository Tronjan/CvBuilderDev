using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Services;
using CvBuilderDev.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CvBuilderDev.Areas.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICreateToken _createToken;
        public AccountsController(IAccountService accountService, ICreateToken createToken)
        {
            _accountService = accountService;
            _createToken = createToken;
        }

        
        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequestViewModel request)
        {
            var token = _createToken.Createtoken(request);
            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> users()
        {
            var user = new UserViewModel
            {
                Email = "test@test.com"
            };

            return Ok(user);
        }

     
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] UserViewModel userViewModel)
        {
            var response = await _accountService.GetLoginResponse(userViewModel);
            if (response.Response == Constants.LOGIN_FAILED)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            if(response.Email != userViewModel.Email)
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var newRefreshToken = await _createToken.CreateRefreshToken();

            var user = await _accountService.GetUserDetails(userViewModel.Email);

            newRefreshToken.UserId = user.Id;
            response.UserId = user.Id;
            await SetRefreshToken(newRefreshToken);

            return Ok(response);
        }

        private async Task SetRefreshToken(RefreshTokenViewModel refreshTokenViewModel)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = refreshTokenViewModel.Expired
            };

            Response.Cookies.Append("refreshToken", refreshTokenViewModel.RefreshToken, cookieOptions);
            Response.Cookies.Append("userId", refreshTokenViewModel.UserId.ToString(), cookieOptions);
            await _createToken.UpdateRefreshToken(refreshTokenViewModel);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var userId = Convert.ToInt16(Request.Cookies["userId"]);

            var tokenDetails = await _accountService.GetRefreshToken(userId);
            if (!tokenDetails.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token");
            }else if(tokenDetails.Expired < DateTime.UtcNow)
            {
                return Unauthorized("Token Expired");
            }

            var userDetails = await _accountService.GetUserDetailsById(userId);

            var tokenPara = new TokenGenerationRequestViewModel()
            {
                Email = userDetails.Email,
                UserId = userId
            };
            var jwtToken = _createToken.Createtoken(tokenPara);

            var newRefreshToken = await _createToken.CreateRefreshToken();
            newRefreshToken.UserId = userId;

            await SetRefreshToken(newRefreshToken);

            return Ok(jwtToken);
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> New([FromBody] RegisterViewModel model)
        {

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var response = await _accountService.CreateNewUser(model);
            if (response == false)
            {
                throw new Exception("User already exist");
            }
            return Created("success", response);
        }
    }
}

