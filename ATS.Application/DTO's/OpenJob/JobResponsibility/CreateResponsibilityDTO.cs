
namespace ATS.Application.DTO_s.OpenJob.JobResponsibility
{
    public class CreateResponsibilityDTO : BaseResponsibilityDTO
    {
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
