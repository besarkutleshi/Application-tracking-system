using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.CreateProfile
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, CreateApplicantProfileDto>
    {
        private readonly IApplicantProfile _applicantProfile;
        private readonly IMapper _mapper;

        public CreateProfileHandler(IApplicantProfile applicantProfile, IMapper mapper)
        {
            _applicantProfile = applicantProfile;
            _mapper = mapper;
        }

        public async Task<CreateApplicantProfileDto> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.createApplicantProfile.ApplicantWorkExperiences)
            {
                if (item.OnGoing == 1)
                {
                    item.EndDate = null;
                }
            }

            foreach (var item in request.createApplicantProfile.ApplicantEducations)
            {
                if (item.OnGoing == 1)
                {
                    item.EndDate = null;
                }
            }

            var applicantProfile = _mapper.Map<ATS.Domain.Models.ApplicantProfile>(request.createApplicantProfile);
            var created = await _applicantProfile.AddAsync(applicantProfile, cancellationToken);
            return _mapper.Map<CreateApplicantProfileDto>(created); 
        }
    }
}
