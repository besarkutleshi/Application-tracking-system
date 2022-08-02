using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperienceCertificate
{
    public class DeleteWorkExperienceCertificateHandler : IRequestHandler<DeleteWorkExperienceCertificateCommand, string>
    {
        private readonly IApplicantExperience _applicantExperience;

        public DeleteWorkExperienceCertificateHandler(IApplicantExperience applicantExperience)
        {
            _applicantExperience = applicantExperience;
        }

        public async Task<string> Handle(DeleteWorkExperienceCertificateCommand request, CancellationToken cancellationToken)
        {
            if (request.experienceId < 1) throw new Exception("Experience Id must be greater than 0.");

            return await _applicantExperience.DeleteExperienceCertificate(request.experienceId, cancellationToken);
        }
    }
}
