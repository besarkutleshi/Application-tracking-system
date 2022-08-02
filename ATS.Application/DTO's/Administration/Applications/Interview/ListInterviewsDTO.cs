using ATS.Application.DTO_s.Administration.Applications.Application;

namespace ATS.Application.DTO_s.Administration.Applications.Interview
{
    public class ListInterviewsDTO
    {
        public int Id { get; set; }
        public DateTime? InterviewDate { get; set; }
        public short? IsConfirmed { get; set; }
        public string Description { get; set; } = string.Empty;

        public ListApplicationsDTO Application { get; set; }
    }
}
