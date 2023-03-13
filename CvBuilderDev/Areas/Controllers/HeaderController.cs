using System;
using CvBuilderDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace CvBuilderDev.Areas.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class HeaderController : Controller
	{
		private readonly IHeaderService _headerService;
		public HeaderController(IHeaderService headerService)
		{
			_headerService = headerService;
		}

		[HttpGet]
		[Route("get")]
		public async Task<IActionResult> Get([FromQuery] string email)
		{
			var header = await _headerService.GetHeader(email);
			return Ok(header);
		}
	}
}

