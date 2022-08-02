using Microsoft.AspNetCore.Http;

namespace ATS.Application.DTO_s.OpenJob.JobCategory
{
    public class CreateJobCategoryDTO : BaseJobCategoryDTO
    {
        public IFormFile PhotoFile { get; set; }
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
