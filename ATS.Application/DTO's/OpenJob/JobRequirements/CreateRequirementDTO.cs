
namespace ATS.Application.DTO_s.OpenJob.JobRequirements
{
    public class CreateRequirementDTO : BaseRequirementsDTO
    {
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
