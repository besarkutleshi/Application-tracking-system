using ATS.Application.DTO_s.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.CreateProfile
{
    public record CreateProfileCommand(CreateApplicantProfileDto createApplicantProfile) : IRequest<CreateApplicantProfileDto>;
}
