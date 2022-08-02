using ATS.Application.DTO_s.OpenJob.JobVacancy;
using ATS.Application.Features.JobVacancy.JobRequirement.Commands.CreateJobRequirement;
using ATS.Application.Features.JobVacancy.JobResponsibility.Commands.CreateJobResponsibility;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.CreateJobVacancy
{
    public class CreateJobVacancyValidator : AbstractValidator<CreateJobDTO>
    {
        public CreateJobVacancyValidator()
        {
            RuleFor(a => a.JobName).NotEmpty();
            RuleFor(a => a.JobNameEn).NotEmpty();
            RuleFor(a => a.Departament).NotEmpty();
            RuleFor(a => a.Division).NotEmpty();
            RuleFor(a => a.JobLocation).NotEmpty();
            RuleFor(a => a.NoEmployeesWanted).GreaterThan(0);
            RuleFor(a => a.JobType).NotEmpty();
            RuleFor(a => a.ExperienceLevel).NotEmpty();
            RuleFor(a => a.ExpireDate).NotEmpty();
            RuleFor(a => a.CategoryId).GreaterThan(0);
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleForEach(a => a.OpenJobsRequirements).SetValidator(new CreateJobRequirementValidator());
            RuleForEach(a => a.OpenJobsResponsibilities).SetValidator(new CreateJobResponsibilityValidator());
        }
    }
}
