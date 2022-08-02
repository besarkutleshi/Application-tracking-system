using ATS.Application.DTO_s.Applicant.Education;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.CreateEducation
{
    public class CreateEducationValidator : AbstractValidator<CreateEducationDTO>
    {
        public CreateEducationValidator()
        {
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.UserId).NotEmpty();
            RuleFor(e => e.Institution).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.AplicantProfileId).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Country).NotEmpty();
            RuleFor(e => e.Direction).NotEmpty();
            RuleFor(e => e.InsertBy).NotEmpty();
            RuleFor(e => e.InsertBy).GreaterThan(0);
        }
    }
}
