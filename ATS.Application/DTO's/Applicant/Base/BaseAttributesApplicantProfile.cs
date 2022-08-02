
namespace ATS.Application.DTO_s.Applicant.Base
{
    public class BaseAttributesApplicantProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Institution { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short OnGoing { get; set; }
        public string? Description { get; set; }
        public short IsActive { get; set; }
    }
}
