
namespace ATS.Application.DTO_s.Applicant.Skill
{
	public class UpdateSkillDTO : BaseSkillsDTO
	{
		public int UpdateBy { get; set; }
		public DateTime? UpdateDate { get; } = DateTime.Now;
	}
}
