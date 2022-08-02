using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.Applicant.Profile
{
    public class UpdateApplicantProfileDto : BaseApplicantProfileDTO
    {
        public IFormFile PhotoFile { get; set; }
        public string LastImageName { get; set; } = String.Empty;
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; } = DateTime.Now;
    }
}
