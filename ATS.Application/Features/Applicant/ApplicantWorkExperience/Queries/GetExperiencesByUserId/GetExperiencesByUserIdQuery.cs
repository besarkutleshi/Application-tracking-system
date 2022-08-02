using ATS.Application.DTO_s.Applicant.Experiences;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Queries.GetExperiencesByUserId
{
    public record GetExperiencesByUserIdQuery(int userId) : IRequest<List<ListWorkExperienceDTO>>;
}
