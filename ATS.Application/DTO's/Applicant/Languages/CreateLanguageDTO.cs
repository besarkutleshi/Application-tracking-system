
namespace ATS.Application.DTO_s.Applicant.Languages
{
	public class CreateLanguageDTO : BaseLanguageDTO
	{
		public int InsertBy { get; set; }
		public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
