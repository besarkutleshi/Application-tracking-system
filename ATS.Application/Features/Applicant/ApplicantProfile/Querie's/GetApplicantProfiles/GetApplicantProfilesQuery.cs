using ATS.Application.DTO_s.Applicant.Profile;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Querie_s.GetApplicantProfiles
{
    public record GetApplicantProfilesQuery : IRequest<List<ListApplicantProfileDto>>;
}
