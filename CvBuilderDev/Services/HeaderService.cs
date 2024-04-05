using System;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Data.Models;
using CvBuilderDev.Repositories;

namespace CvBuilderDev.Services
{
	public interface IHeaderService
	{
		Task CreateHeader(HeaderViewModel model);
		Task<HeaderViewModel> GetHeader(string email);

	}
	public class HeaderService : IHeaderService
	{
		private readonly IHeaderRepository _headerRepository;
		public HeaderService(IHeaderRepository headerRepository)
		{
			_headerRepository = headerRepository;
		}

		public async Task CreateHeader(HeaderViewModel model)
		{
			var newHeader = new HeaderModel
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Phonenumber = model.Phonenumber,
				LinkedInId = model.LinkedInId,
				City = model.City,
				ProfilePicture = model.ProfilePicture
			};

			await _headerRepository.CreateHeader(newHeader);
		}

		public async Task<HeaderViewModel> GetHeader(string email)
		{
			var headerData = await _headerRepository.GetHeader(email);
			var newHeaderData = new HeaderViewModel()
			{
				FirstName = headerData.FirstName,
				LastName = headerData.LastName,
				Email = headerData.Email,
				Phonenumber = headerData.Phonenumber,
				LinkedInId = headerData.LinkedInId,
				City = headerData.City,
				ProfilePicture = headerData.ProfilePicture
			};
			return newHeaderData;
		}
	}
}