using System;
namespace CvBuilderDev.Services
{
	public interface IWorkExperienceIService
	{
		public Task GetWotkExperience(int wid, string expName);
	}
	public class WorkExperienceService : IWorkExperienceIService
	{
		public WorkExperienceService()
		{
		}

		public async Task<int> GetWorkExperience(int wid, string expName)
		{
			return 1;
		}

        public Task GetWotkExperience(int wid, string expName)
        {
            throw new NotImplementedException();
        }
    }
}

