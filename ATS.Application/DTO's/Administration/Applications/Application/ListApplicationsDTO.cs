using ATS.Application.DTO_s.Applicant.Profile;
using ATS.Application.DTO_s.OpenJob.JobCategory;
using ATS.Application.DTO_s.OpenJob.JobVacancy;

namespace ATS.Application.DTO_s.Administration.Applications.Application
{
    public class ListApplicationsDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int DayAgo { get; set; }

        public ListJobDTO OpenJob { get; set; }
        public ListApplicantProfileDto AplicantProfile { get; set; }
        public ListJobCategoryDTO Category { get; set; }
    }
}
