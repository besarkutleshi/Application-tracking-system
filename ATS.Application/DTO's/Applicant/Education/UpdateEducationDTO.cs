using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Education
{
    public class UpdateEducationDTO : BaseEducationDTO
	{
		public int UpdateBy { get; set; }
		public string? LastCertificateName { get; set; }
		public IFormFile? Certificate { get; set; }
		public List<EducationCertificateDTO> ApplicantCertificates { get; set; }

        public UpdateEducationDTO()
        {
            ApplicantCertificates = new List<EducationCertificateDTO>();
        }
    }
}
