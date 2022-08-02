using ATS.Application.DTO_s.Applicant.Languages;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.UpdateApplicantLanguage
{
    public record UpdateLanguageCommand(UpdateLanguageDTO updateLanguage) : IRequest<bool>;
}
