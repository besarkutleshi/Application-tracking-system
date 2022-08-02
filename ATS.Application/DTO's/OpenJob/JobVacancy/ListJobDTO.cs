using ATS.Application.DTO_s.OpenJob.JobCategory;

namespace ATS.Application.DTO_s.OpenJob.JobVacancy
{
    public class ListJobDTO : BaseJobDTO
    {
        public ListJobCategoryDTO Category { get; set; }
        public DateTime CreatedDate { get; set; }

        public ListJobDTO(ListJobCategoryDTO category)
        {
            Category = category;
        }
    }
}
