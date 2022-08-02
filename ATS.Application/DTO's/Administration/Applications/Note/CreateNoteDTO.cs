
namespace ATS.Application.DTO_s.Administration.Applications
{
    public class CreateNoteDTO
    {
        public int ApplicationId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; } = DateTime.Now;
    }
}
