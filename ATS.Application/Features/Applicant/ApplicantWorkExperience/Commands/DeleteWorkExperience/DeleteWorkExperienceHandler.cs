using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperience
{
    public class DeleteWorkExperienceHandler : IRequestHandler<DeleteWorkExperienceCommand, bool>
    {
        private readonly IApplicantExperience _applicantExperience;

        public DeleteWorkExperienceHandler(IApplicantExperience applicantExperience)
        {
            _applicantExperience = applicantExperience;
        }

        public async Task<bool> Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("Work experience ID must be greater than 0");

            return await _applicantExperience.DeleteAsync(request.id, cancellationToken);
        }
    }
}
