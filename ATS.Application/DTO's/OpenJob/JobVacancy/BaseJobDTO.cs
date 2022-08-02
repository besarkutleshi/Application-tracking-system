
namespace ATS.Application.DTO_s.OpenJob.JobVacancy
{
    public abstract class BaseJobDTO
    {
        public int Id { get; set; }
        public string JobName { get; set; } = String.Empty;
        public string JobNameEn { get; set; } = String.Empty;
        public string? JobNameSr { get; set; }
        public string Departament { get; set; } = String.Empty;
        public string Division { get; set; } = String.Empty;
        public string JobLocation { get; set; } = String.Empty;
        public int NoEmployeesWanted { get; set; }
        public string JobType { get; set; } = String.Empty;
        public string ExperienceLevel { get; set; } = String.Empty;
        public DateTime ExpireDate { get; set; }
        public string? Description { get; set; }
        public short? IsRemote { get; set; }
        public int CategoryId { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionSr { get; set; }
    }
}
