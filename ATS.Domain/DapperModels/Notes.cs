
namespace ATS.Domain.DapperModels
{
    public class Notes
    {
        public int Id { get; set; }
        public int ApplicantProfileId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime NodeDate { get; set; }
        public string NoteText { get; set; } = string.Empty;
    }
}
