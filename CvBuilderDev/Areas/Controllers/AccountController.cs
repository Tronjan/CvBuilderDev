using System;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace CvBuilderDev.Areas.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;           
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Get([FromBody] UserViewModel userViewModel)
        {
            var response = await _accountService.GetLoginResponse(userViewModel);
            if(response == false)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> New([FromBody] HeaderViewModel model)
        {
            await _accountService
            return Ok();
        }
    }
}

