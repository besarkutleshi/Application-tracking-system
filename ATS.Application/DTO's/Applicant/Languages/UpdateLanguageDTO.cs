
namespace ATS.Application.DTO_s.Applicant.Languages
{
	public class UpdateLanguageDTO : BaseLanguageDTO
	{
		public int UpdateBy { get; set; }
		public DateTime? UpdateDate { get; } = DateTime.Now;
    }
}
