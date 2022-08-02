namespace ATS.Application.DTO_s.Administration.Applications.Interview
{
    public class CreateInterviewDTO
    {
        public int? ApplicationId { get; set; }
        public DateTime? InterviewDate { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
