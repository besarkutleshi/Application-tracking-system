
using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Education
{
    public class EducationCertificateDTO
    {
        public int Id { get; set; }
        public int ApplicantEducationId { get; set; }
        public string CertificateName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public IFormFile Certificate { get; set; }
    }
}
