using ATS.Application.DTO_s.Applicant.Education;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.UpdateEducation
{
    public class UpdateEducationValidator : AbstractValidator<UpdateEducationDTO>
    {
        public UpdateEducationValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Id).GreaterThan(0);
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.UserId).NotEmpty();
            RuleFor(e => e.Institution).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.AplicantProfileId).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Country).NotEmpty();
            RuleFor(e => e.Direction).NotEmpty();
            RuleFor(e => e.UpdateBy).NotEmpty();
            RuleFor(e => e.UpdateBy).GreaterThan(0);
        }
    }
}
