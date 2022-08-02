
namespace ATS.Application.DTO_s.OpenJob.JobCategory
{
    public abstract class BaseJobCategoryDTO
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string CategoryAlbania { get; set; } = string.Empty;
        public string? Photo { get; set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
    }
}
