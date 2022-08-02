
namespace ATS.Application.DTO_s.OpenJob.JobRequirements
{
    public abstract class BaseRequirementsDTO
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string Requirement { get; set; } = string.Empty;
        public string RequirementEn { get; set; } = string.Empty;
        public string RequirementSr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
