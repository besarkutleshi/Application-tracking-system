using ATS.Application.DTO_s.Applicant.Profile;

namespace ATS.Application.DTO_s.Administration.Applications.Question
{
    public class ApplicationQuestionDTO
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }

        public short HasAnswer { get; set; }
        public string Answer { get; set; } = string.Empty;

        public ListApplicantProfileDto AplicantProfile { get; set; }
        public QuestionDTO Question { get; set; }
    }
}
