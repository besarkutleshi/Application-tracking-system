using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.OpenJob.JobCategory
{
    public class UpdateJobCategoryDTO : BaseJobCategoryDTO
    {
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; } = DateTime.Now;
        public string LastImage { get; set; } = string.Empty;
        public IFormFile PhotoFile { get; set; }
    }
}
