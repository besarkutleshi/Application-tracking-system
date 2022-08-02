
namespace ATS.Application.DTO_s.Applicant.Skill
{
	public class CreateSkillDTO : BaseSkillsDTO
	{
		public int InsertBy { get; set; }
		public DateTime? InsertDate { get; } = DateTime.Now;
    }
}
