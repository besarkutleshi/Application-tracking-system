using ATS.Application.DTO_s.OpenJob.JobCategory;
using ATS.Application.DTO_s.OpenJob.JobRequirements;
using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using ATS.Application.DTO_s.OpenJob.JobVacancy;
using ATS.Domain.Models;
using AutoMapper;

namespace ATS.Application.Mappings
{
    public class JobVacancyProfile : Profile
    {
        public JobVacancyProfile()
        {
            CreateMap<OpenJob, CreateJobDTO>().ReverseMap();
            CreateMap<OpenJob, UpdateJobDTO>().ReverseMap();
            CreateMap<OpenJob, ListJobDTO>();

            CreateMap<OpenJobsRequirement, CreateRequirementDTO>().ReverseMap();
            CreateMap<OpenJobsRequirement, UpdateRequirementDTO>().ReverseMap();
            CreateMap<OpenJobsRequirement, ListRequirementsDTO>();


            CreateMap<OpenJobsResponsibility, CreateResponsibilityDTO>().ReverseMap();
            CreateMap<OpenJobsResponsibility, UpdateResponsibilityDTO>().ReverseMap();
            CreateMap<OpenJobsResponsibility, ListResponsibilityDTO>();

            CreateMap<JobCategory, CreateJobCategoryDTO>().ReverseMap();
            CreateMap<JobCategory, UpdateJobCategoryDTO>().ReverseMap();
            CreateMap<JobCategory, ListJobCategoryDTO>();

        }
    }
}
