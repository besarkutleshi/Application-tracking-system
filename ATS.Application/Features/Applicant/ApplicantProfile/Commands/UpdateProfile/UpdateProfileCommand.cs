using ATS.Application.DTO_s.Applicant.Profile;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.UpdateProfile
{
    public record UpdateProfileCommand(UpdateApplicantProfileDto updateApplicantProfile) : IRequest<bool>;
}
