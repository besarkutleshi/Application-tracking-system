using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.UpdateProfile
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IApplicantProfile _applicantProfile;
        private readonly IMapper _mapper;

        public UpdateProfileHandler(IApplicantProfile applicantProfile, IMapper mapper)
        {
            _applicantProfile = applicantProfile;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<ATS.Domain.Models.ApplicantProfile>(request.updateApplicantProfile);
            var updated = await _applicantProfile.UpdateAsync(profile, cancellationToken);
            return updated;
        }
    }
}
