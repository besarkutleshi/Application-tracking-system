
namespace ATS.Application.DTO_s.Administration.Applications.Application
{
    public class UpdateApplicationsDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;

        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; private set; } = DateTime.Now;
    }
}
