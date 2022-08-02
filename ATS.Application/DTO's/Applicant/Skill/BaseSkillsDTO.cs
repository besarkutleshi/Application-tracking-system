
namespace ATS.Application.DTO_s.Applicant.Skill
{
	public abstract class BaseSkillsDTO
	{
        public int Id { get; set; }
        public string? Skill { get; set; }
		public string? KnowledgeLevel { get; set; }
		public short? IsActive { get; set; }
		public int? UserId { get; set; }
		public int? AplicantProfileId { get; set; }
	}
}
