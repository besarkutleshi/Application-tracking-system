using ATS.Application.DTO_s.Applicant.Base;

namespace ATS.Application.DTO_s.Applicant.Education
{
    public abstract class BaseEducationDTO
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
        public int AplicantProfileId { get; set; }
        public string? Direction { get; set; }
        public string? Address { get; set; }
    }
}
