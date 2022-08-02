using ATS.Application.DTO_s.Applicant;
using ATS.Application.DTO_s.Applicant.Education;
using ATS.Application.DTO_s.Applicant.Experiences;
using ATS.Application.DTO_s.Applicant.Languages;
using ATS.Application.DTO_s.Applicant.Profile;
using ATS.Application.DTO_s.Applicant.Skill;
using ATS.Domain.Models;
using AutoMapper;

namespace ATS.Application.Mappings
{
    public class ApplicantMappingProfile : Profile
    {
        public ApplicantMappingProfile()
        {
            CreateMap<CreateApplicantProfileDto, ApplicantProfile>().ReverseMap();
            CreateMap<UpdateApplicantProfileDto, ApplicantProfile>().ReverseMap();
            CreateMap<ApplicantProfile, ListApplicantProfileDto>();

            CreateMap<ListSkillsDTO, ApplicantSkill>().ReverseMap();
            CreateMap<CreateSkillDTO, ApplicantSkill>().ReverseMap();
            CreateMap<UpdateSkillDTO, ApplicantSkill>().ReverseMap();

            CreateMap<ListLanguagesDTO, ApplicantLanguage>().ReverseMap();
            CreateMap<CreateLanguageDTO, ApplicantLanguage>().ReverseMap();
            CreateMap<UpdateLanguageDTO, ApplicantLanguage>().ReverseMap();

            #region Education mappings
            CreateMap<CreateEducationDTO, ApplicantEducation>().ReverseMap();
            CreateMap<UpdateEducationDTO, ApplicantEducation>().ReverseMap();
            CreateMap<ApplicantEducation, ListEducationDTO>();

            CreateMap<EducationCertificateDTO, ApplicantCertificate>().ReverseMap();
            #endregion

            CreateMap<CreateWorkExperienceDTO, ApplicantWorkExperience>().ReverseMap();
            CreateMap<UpdateWorkExperienceDTO, ApplicantWorkExperience>().ReverseMap();
            CreateMap<ListWorkExperienceDTO, ApplicantWorkExperience>();
        }
    }
}
