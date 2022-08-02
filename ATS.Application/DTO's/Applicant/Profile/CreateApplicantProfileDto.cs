using ATS.Application.DTO_s.Applicant.Education;
using ATS.Application.DTO_s.Applicant.Experiences;
using ATS.Application.DTO_s.Applicant.Languages;
using ATS.Application.DTO_s.Applicant.Skill;

namespace ATS.Application.DTO_s.Applicant
{
    public class CreateApplicantProfileDto : BaseApplicantProfileDTO
    {
        public CreateApplicantProfileDto(List<CreateEducationDTO> applicantEducations, List<CreateWorkExperienceDTO> applicantWorkExperiences, List<CreateSkillDTO> applicantSkills, List<CreateLanguageDTO> applicantLanguages)
        {
            ApplicantEducations = applicantEducations;
            ApplicantWorkExperiences = applicantWorkExperiences;
            ApplicantSkills = applicantSkills;
            ApplicantLanguages = applicantLanguages;
        }

        public List<CreateEducationDTO> ApplicantEducations { get; set; }
        public List<CreateWorkExperienceDTO> ApplicantWorkExperiences { get; set; }
        public List<CreateSkillDTO> ApplicantSkills { get; set; }
        public List<CreateLanguageDTO> ApplicantLanguages { get; set; }

        //public int InsertBy { get; set; }
        //public DateTime InsertDate { get; } = DateTime.Now;
    }
}
