using ATS.Application.DTO_s.Applicant.Languages;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.UpdateApplicantLanguage
{
    public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageDTO>
    {
        public UpdateLanguageValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThan(0);

            RuleFor(a => a.Language).NotEmpty();
            RuleFor(a => a.KnowledgeLevel).NotEmpty();

            RuleFor(a => a.UpdateBy).NotEmpty();

            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.UserId).GreaterThan(0);

            RuleFor(a => a.AplicantProfileId).NotEmpty();
            RuleFor(a => a.AplicantProfileId).GreaterThan(0);
        }
    }
}
