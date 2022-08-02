using ATS.Application.DTO_s.Applicant.Education;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.AddEducationCertificate
{
    public record AddEducationCertificateCommand(EducationCertificateDTO educationCertificate) : IRequest<bool>;
}
