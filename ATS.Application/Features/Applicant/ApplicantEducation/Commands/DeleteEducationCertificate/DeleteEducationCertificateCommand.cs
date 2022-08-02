using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducationCertificate
{
    public record DeleteEducationCertificateCommand(int educationId) : IRequest<string>;
}
