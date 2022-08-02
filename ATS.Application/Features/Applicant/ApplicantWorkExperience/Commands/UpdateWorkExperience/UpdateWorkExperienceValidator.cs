using ATS.Application.DTO_s.Applicant.Experiences;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.UpdateWorkExperience
{
    public class UpdateWorkExperienceValidator : AbstractValidator<UpdateWorkExperienceDTO>
    {
        public UpdateWorkExperienceValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.ApplicantProfileId).NotEmpty();
            RuleFor(a => a.ApplicantProfileId).GreaterThan(0);
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.Institution).NotEmpty();
            RuleFor(a => a.Position).NotEmpty();
            RuleFor(a => a.StartDate).NotEmpty();
            RuleFor(a => a.UpdateBy).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.UserId).GreaterThan(0);
        }
    }
}
