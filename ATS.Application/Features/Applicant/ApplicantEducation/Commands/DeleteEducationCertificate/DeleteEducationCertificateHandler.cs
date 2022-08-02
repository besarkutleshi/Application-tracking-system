using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducationCertificate
{
    public class DeleteEducationCertificateHandler : IRequestHandler<DeleteEducationCertificateCommand, string>
    {
        private readonly IApplicantEducation _applicantEducation;

        public DeleteEducationCertificateHandler(IApplicantEducation applicantEducation)
        {
            _applicantEducation = applicantEducation;
        }

        public async Task<string> Handle(DeleteEducationCertificateCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _applicantEducation.DeleteEducationCertificate(request.educationId, cancellationToken);
            return deleted;
        }
    }
}
