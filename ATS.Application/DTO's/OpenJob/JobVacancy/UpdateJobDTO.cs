
namespace ATS.Application.DTO_s.OpenJob.JobVacancy
{
    public class UpdateJobDTO : BaseJobDTO
    {
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; } = DateTime.Now;
    }
}
