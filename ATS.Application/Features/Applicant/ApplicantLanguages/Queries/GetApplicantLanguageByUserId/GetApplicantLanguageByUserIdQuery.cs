using ATS.Application.DTO_s.Applicant.Languages;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Queries.GetApplicantLanguageByUserId
{
    public record GetApplicantLanguageByUserIdQuery(int userId) : IRequest<List<ListLanguagesDTO>>;
}
