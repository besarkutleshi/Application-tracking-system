
namespace ATS.Application.DTO_s.Administration.Applications.Interview
{
    public class UpdateInterviewDTO
    {
        public int Id { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; private set; } = DateTime.Now;
    }
}
