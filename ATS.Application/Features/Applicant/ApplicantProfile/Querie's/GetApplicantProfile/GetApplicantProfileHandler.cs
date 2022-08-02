using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Profile;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Querie_s.GetApplicantProfile
{
    public class GetApplicantProfileHandler : IRequestHandler<GetApplicantProfileQuery, ListApplicantProfileDto>
    {
        private readonly IApplicantProfile _applicantProfile;
        private readonly IMapper _mapper;

        public GetApplicantProfileHandler(IApplicantProfile applicantProfile, IMapper mapper)
        {
            _applicantProfile = applicantProfile;
            _mapper = mapper;
        }

        public async Task<ListApplicantProfileDto> Handle(GetApplicantProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _applicantProfile.GetAsync(request.userId, cancellationToken);
            if (profile == null) throw new Exception("Profile not found.");

            return _mapper.Map<ListApplicantProfileDto>(profile);

        }
    }
}
