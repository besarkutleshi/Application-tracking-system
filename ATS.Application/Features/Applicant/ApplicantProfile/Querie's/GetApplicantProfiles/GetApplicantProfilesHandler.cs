using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Profile;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Querie_s.GetApplicantProfiles
{
    public class GetApplicantProfilesHandler : IRequestHandler<GetApplicantProfilesQuery, List<ListApplicantProfileDto>>
    {
        private readonly IApplicantProfile _applicantProfile;
        private readonly IMapper _mapper;

        public GetApplicantProfilesHandler(IApplicantProfile applicantProfile, IMapper mapper)
        {
            _applicantProfile = applicantProfile;
            _mapper = mapper;
        }

        public async Task<List<ListApplicantProfileDto>> Handle(GetApplicantProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _applicantProfile.GetListAsync(cancellationToken);
            return _mapper.Map<List<ListApplicantProfileDto>>(profiles);
        }
    }
}
