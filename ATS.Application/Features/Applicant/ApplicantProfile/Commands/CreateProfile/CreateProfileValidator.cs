using ATS.Application.DTO_s.Applicant;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.CreateProfile
{
    public class CreateProfileValidator : AbstractValidator<CreateApplicantProfileDto>
    {
        public CreateProfileValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Surname).NotEmpty();
            RuleFor(p => p.PersonalNumber).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserId).GreaterThan(0);
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.BirthDate).NotEmpty();
            RuleFor(p => p.BirthPlace).NotEmpty();
            RuleFor(p => p.CurrentCountry).NotEmpty();
            RuleFor(p => p.BirthCountry).NotNull();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Phone).NotEmpty();
            RuleFor(p => p.Gender).NotEmpty();
            RuleFor(p => p.ApplicantEducations).NotEmpty();
            RuleFor(p => p.ApplicantEducations.Count).GreaterThan(0);
            RuleFor(p => p.ApplicantLanguages).NotEmpty();
            RuleFor(p => p.ApplicantLanguages.Count).GreaterThan(0);
            //RuleFor(p => p.InsertBy).NotEmpty();
            //RuleFor(p => p.InsertBy).GreaterThan(0);
        }
    }
}
