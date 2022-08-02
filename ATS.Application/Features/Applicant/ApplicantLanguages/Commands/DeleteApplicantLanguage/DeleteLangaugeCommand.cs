using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.DeleteApplicantLanguage
{
    public record DeleteLangaugeCommand(int languageId) : IRequest<bool>;
}
