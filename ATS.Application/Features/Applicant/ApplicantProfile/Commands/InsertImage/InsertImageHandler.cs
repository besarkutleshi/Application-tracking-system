using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.InsertImage
{
    public class InsertImageHandler : IRequestHandler<InsertImageCommand, bool>
    {
        private readonly IApplicantProfile _applicantProfile;

        public InsertImageHandler(IApplicantProfile applicantProfile)
        {
            _applicantProfile = applicantProfile;
        }

        public async Task<bool> Handle(InsertImageCommand request, CancellationToken cancellationToken)
        {
            var inserted = await _applicantProfile.InsertImage(request.InsertImage.ProfileId, request.InsertImage.ImageName, cancellationToken);
            return inserted;
        }
    }
}
