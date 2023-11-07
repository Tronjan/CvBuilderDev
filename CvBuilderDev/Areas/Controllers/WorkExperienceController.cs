using System;
using Microsoft.AspNetCore.Mvc;
using CvBuilderDev.Services;
namespace CvBuilderDev.Areas.Controllers
{
	[ApiController]
	[Route("api/Controller")]
	public class WorkExperienceController : Controller
	{
		private readonly IWorkExperienceIService _workExperienceIService;

		public WorkExperienceController(IWorkExperienceIService workExperienceIService)
		{
			_workExperienceIService = workExperienceIService;
		}

		[HttpGet]
		[Route("workexp/get")]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}
	}
}

