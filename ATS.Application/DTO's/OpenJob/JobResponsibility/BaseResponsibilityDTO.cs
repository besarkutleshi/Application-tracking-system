
namespace ATS.Application.DTO_s.OpenJob.JobResponsibility
{
    public abstract class BaseResponsibilityDTO
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string Responsibility { get; set; } = string.Empty;
        public string ResponsibilityEn { get; set; } = string.Empty;
        public string ResponsibilitySr { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
