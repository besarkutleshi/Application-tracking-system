using ATS.Application.DTO_s.Applicant.Profile;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Querie_s
{
    public record GetApplicantProfileQuery(int userId) : IRequest<ListApplicantProfileDto>;
}
