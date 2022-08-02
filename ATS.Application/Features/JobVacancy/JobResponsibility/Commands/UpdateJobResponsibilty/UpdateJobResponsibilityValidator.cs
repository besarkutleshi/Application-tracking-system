using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.UpdateJobResponsibilty
{
    public class UpdateJobResponsibilityValidator : AbstractValidator<UpdateResponsibilityDTO>
    {
        public UpdateJobResponsibilityValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.Responsibility).NotEmpty();
            RuleFor(a => a.ResponsibilityEn).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
            RuleFor(a => a.JobId).GreaterThan(0);
        }
    }
}
