using ATS.Application.DTO_s.Applicant.Languages;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.CreateApplicantLanguage
{
    public class CreateLanguageValidator : AbstractValidator<CreateLanguageDTO>
    {
        public CreateLanguageValidator()
        {
            RuleFor(a => a.KnowledgeLevel).NotEmpty();
            RuleFor(a => a.InsertBy).NotEmpty();
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.AplicantProfileId).NotEmpty();
            RuleFor(a => a.Language).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.AplicantProfileId).GreaterThan(0);
        }
    }
}
