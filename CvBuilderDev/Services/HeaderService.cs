using System;
using CvBuilderDev.Areas.Models;
using CvBuilderDev.Data.Models;
using CvBuilderDev.Repositories;

namespace CvBuilderDev.Services
{
	public interface IHeaderService
	{
        Task CreateOrUpdateHeader(HeaderViewModel model);
        Task<HeaderViewModel> GetHeader(string email);

    }
	public class HeaderService : IHeaderService
	{
		private readonly IHeaderRepository _headerRepository;
		public HeaderService(IHeaderRepository headerRepository)
		{
			_headerRepository = headerRepository;
		}

        public async Task CreateOrUpdateHeader(HeaderViewModel model)
        {	
			await _headerRepository.CreateOrUpdateHeader(model);
        }

        public async Task<HeaderViewModel> GetHeader(string email)
		{
            var headerData = await _headerRepository.GetHeader(email);
			var newHeaderData = new HeaderViewModel()
			{
				Id = headerData.Id,
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

