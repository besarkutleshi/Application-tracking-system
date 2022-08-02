using ATS.Application.DTO_s.OpenJob.JobRequirements;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.CreateJobRequirement
{
    public class CreateJobRequirementValidator : AbstractValidator<CreateRequirementDTO>
    {
        public CreateJobRequirementValidator()
        {
            RuleFor(a => a.Requirement).NotEmpty();
            RuleFor(a => a.RequirementEn).NotEmpty();
            RuleFor(a => a.JobId).NotEmpty();
            RuleFor(a => a.JobId).GreaterThan(0);
            RuleFor(a => a.InsertBy).GreaterThan(0);
        }
    }
}
