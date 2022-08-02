using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Education
{
	public class CreateEducationDTO : BaseEducationDTO
	{
		public CreateEducationDTO()
		{
			ApplicantCertificates = new List<EducationCertificateDTO>();
		}

		public IFormFile? Certificate { get; set; }
		public List<EducationCertificateDTO> ApplicantCertificates { get; set; }
		public int InsertBy { get; set; }
		private DateTime InsertDate { get; } = DateTime.Now;
	}
}
