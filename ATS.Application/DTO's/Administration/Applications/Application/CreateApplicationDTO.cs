using ATS.Application.DTO_s.Administration.Applications.Question;

namespace ATS.Application.DTO_s.Administration.Applications.Application
{
    public class CreateApplicationDTO
    {
        public int UserId { get; set; }
        public int AplicantProfileId { get; set; }
        public int OpenJobId { get; set; }
        public int ApplicationTypeId { get; set; }
        public string Status { get; set; } = string.Empty;
        public int InsertBy { get; set; }

        public DateTime? ApplicationDate { get; private set; } = DateTime.Now;
        public DateTime? InsertDate { get; private set; } = DateTime.Now;

        public List<CreateApplicationQuestionDTO> AplicantQuestions { get; set; }
    }
}
