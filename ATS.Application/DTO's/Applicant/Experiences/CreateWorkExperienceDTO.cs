using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Experiences
{
	public class CreateWorkExperienceDTO : BaseExperienceDTO
	{
		public int InsertBy { get; set; }
		private DateTime? InsertDate { get; } = DateTime.Now;
        public IFormFile? Certificate { get; set; }
	}
}
