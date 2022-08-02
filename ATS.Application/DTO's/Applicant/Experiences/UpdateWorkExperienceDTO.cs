using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Experiences
{
	public class UpdateWorkExperienceDTO : BaseExperienceDTO
	{
        public int UpdateBy { get; set; }
		private DateTime? UpdateDate { get; } = DateTime.Now;
        public IFormFile? Certificate { get; set; }
		public string? LastFileName { get; set; }
	}
}
