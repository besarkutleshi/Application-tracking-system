
namespace ATS.Application.DTO_s.Applicant
{
    public abstract class BaseApplicantProfileDTO
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string PersonalNumber { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string CurrentCountry { get; set; } = string.Empty;
        public string BirthCountry { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    } 
}
