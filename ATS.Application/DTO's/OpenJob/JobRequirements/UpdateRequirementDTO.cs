
namespace ATS.Application.DTO_s.OpenJob.JobRequirements
{
    public class UpdateRequirementDTO : BaseRequirementsDTO
    {
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; } = DateTime.Now;
    }
}
