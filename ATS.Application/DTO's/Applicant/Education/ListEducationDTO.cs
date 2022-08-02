using Microsoft.AspNetCore.Http;
namespace ATS.Application.DTO_s.Applicant.Education
{
    public class ListEducationDTO : BaseEducationDTO
	{
		public ListEducationDTO()
		{
			ApplicantCertificates = new List<EducationCertificateDTO>();
		}
		public IFormFile? Certifikate { get; set; }
		public List<EducationCertificateDTO> ApplicantCertificates { get; set; }
	}
}
