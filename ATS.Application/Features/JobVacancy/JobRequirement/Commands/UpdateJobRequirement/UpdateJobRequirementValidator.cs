using ATS.Application.DTO_s.OpenJob.JobRequirements;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.UpdateJobRequirement
{
    public class UpdateJobRequirementValidator : AbstractValidator<UpdateRequirementDTO>
    {
        public UpdateJobRequirementValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.Requirement).NotEmpty();
            RuleFor(a => a.RequirementEn).NotEmpty();
            RuleFor(a => a.JobId).GreaterThan(0);
            RuleFor(a => a.UpdateBy).GreaterThan(0);
        }
    }
}
