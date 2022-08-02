using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.CreateJobResponsibility
{
    public class CreateJobResponsibilityValidator : AbstractValidator<CreateResponsibilityDTO>
    {
        public CreateJobResponsibilityValidator()
        {
            RuleFor(a => a.Responsibility).NotEmpty();
            RuleFor(a => a.ResponsibilityEn).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.JobId).GreaterThan(0);
        }
    }
}
