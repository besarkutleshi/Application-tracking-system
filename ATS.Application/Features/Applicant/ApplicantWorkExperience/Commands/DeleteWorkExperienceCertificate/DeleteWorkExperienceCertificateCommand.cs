using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperienceCertificate
{
    public record DeleteWorkExperienceCertificateCommand(int experienceId) : IRequest<string>;
}
