using ATS.Application.DTO_s.Applicant.Experiences;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.CreateWorkExperience
{
    public class CreateWorkExperienceValidator : AbstractValidator<CreateWorkExperienceDTO>
    {
        public CreateWorkExperienceValidator()
        {
            RuleFor(a => a.ApplicantProfileId).NotEmpty();
            RuleFor(a => a.ApplicantProfileId).GreaterThan(0);
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.Institution).NotEmpty();
            RuleFor(a => a.Position).NotEmpty();
            RuleFor(a => a.StartDate).NotEmpty();
            RuleFor(a => a.InsertBy).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.UserId).GreaterThan(0);
        }
    }
}
