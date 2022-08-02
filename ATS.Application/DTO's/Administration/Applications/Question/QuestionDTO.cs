
namespace ATS.Application.DTO_s.Administration.Applications.Question
{
    public class QuestionDTO
    {
        public string QuestionEnglish { get; set; } = string.Empty;
        public string QuestionAlbanian { get; set; } = string.Empty;
        public int ApplicationTypeId { get; set; }
        public string Description { get; set; } = string.Empty;

        public string Placeholder { get; set; } = string.Empty;
        public string PlaceHolderAlbania { get; set; } = string.Empty;
    }
}
