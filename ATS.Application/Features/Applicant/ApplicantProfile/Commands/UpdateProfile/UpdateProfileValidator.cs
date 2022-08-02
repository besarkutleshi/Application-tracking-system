using ATS.Application.DTO_s.Applicant.Profile;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.UpdateProfile
{
    public class UpdateProfileValidator : AbstractValidator<UpdateApplicantProfileDto>
    {
        public UpdateProfileValidator()
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
            RuleFor(p => p.UpdateBy).NotEmpty();
            RuleFor(p => p.UpdateBy).GreaterThan(0);
            RuleFor(p => p.UpdateDate).NotEmpty();
        }
    }
}
