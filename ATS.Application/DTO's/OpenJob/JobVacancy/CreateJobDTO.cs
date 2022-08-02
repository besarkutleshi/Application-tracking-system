using ATS.Application.DTO_s.OpenJob.JobRequirements;
using ATS.Application.DTO_s.OpenJob.JobResponsibility;

namespace ATS.Application.DTO_s.OpenJob.JobVacancy
{
    public class CreateJobDTO : BaseJobDTO
    {
        public CreateJobDTO(List<CreateRequirementDTO> openJobsRequirements, List<CreateResponsibilityDTO> openJobsResponsibilities)
        {
            OpenJobsRequirements = openJobsRequirements;
            OpenJobsResponsibilities = openJobsResponsibilities;
        }

        public List<CreateRequirementDTO> OpenJobsRequirements { get; set; }
        public List<CreateResponsibilityDTO> OpenJobsResponsibilities { get; set; }

        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
