using ATS.Application.DTO_s.Applicant.Languages;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.CreateApplicantLanguage
{
    public record CreateLanguageCommand(CreateLanguageDTO createLanguage) : IRequest<CreateLanguageDTO>;
}
