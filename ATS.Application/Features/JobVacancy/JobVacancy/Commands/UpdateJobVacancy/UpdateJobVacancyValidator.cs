using ATS.Application.DTO_s.OpenJob.JobVacancy;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.UpdateJobVacancy
{
    public class UpdateJobVacancyValidator : AbstractValidator<UpdateJobDTO>
    {
        public UpdateJobVacancyValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
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
            RuleFor(a => a.UpdateBy).GreaterThan(0);
        }
    }
}
