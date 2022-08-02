
namespace ATS.Application.DTO_s.Administration.Applications
{
    public class UpdateNoteDTO
    {
        public int Id { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; } = DateTime.Now;
    }
}
