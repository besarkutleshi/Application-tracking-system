
namespace ATS.Application.DTO_s.Applicant.Languages
{
	public abstract class BaseLanguageDTO
	{
        public int Id { get; set; }
        public int UserId { get; set; }
		public int AplicantProfileId { get; set; }
		public string? Language { get; set; }
		public string? KnowledgeLevel { get; set; }
		public short IsActive { get; set; }
	}
}
