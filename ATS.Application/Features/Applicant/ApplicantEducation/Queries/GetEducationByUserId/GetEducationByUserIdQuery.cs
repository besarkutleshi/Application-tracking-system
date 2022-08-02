using ATS.Application.DTO_s.Applicant.Education;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Queries.GetEducationByUserId
{
    public record GetEducationByUserIdQuery(int userId) : IRequest<List<ListEducationDTO>>;
}
