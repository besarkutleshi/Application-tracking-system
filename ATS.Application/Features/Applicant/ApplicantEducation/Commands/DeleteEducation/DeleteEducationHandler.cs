using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducation
{
    public class DeleteEducationHandler : IRequestHandler<DeleteEducationCommand, bool>
    {
        private readonly IApplicantEducation _applicantEducation;

        public DeleteEducationHandler(IApplicantEducation applicantEducation)
        {
            _applicantEducation = applicantEducation;
        }

        public async Task<bool> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _applicantEducation.DeleteAsync(request.id, cancellationToken);
            return deleted;
        }
    }
}
