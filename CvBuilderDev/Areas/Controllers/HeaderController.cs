using System;
using Microsoft.AspNetCore.Mvc;

namespace CvBuilderDev.Areas.Controllers
{
	public class HeaderController : Controller
	{
		public HeaderController()
		{
		}

		public async Task<IActionResult> Get()
		{
			return Ok();
		}
	}
}

