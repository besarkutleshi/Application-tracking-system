using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Experiences;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Queries.GetExperiencesByUserId
{
    public class GetExperienceByUserIdHandler : IRequestHandler<GetExperiencesByUserIdQuery, List<ListWorkExperienceDTO>>
    {
        private readonly IApplicantExperience _applicantExperience;
        private readonly IMapper _mapper;

        public GetExperienceByUserIdHandler(IApplicantExperience applicantExperience, IMapper mapper)
        {
            _applicantExperience = applicantExperience;
            _mapper = mapper;
        }

        public async Task<List<ListWorkExperienceDTO>> Handle(GetExperiencesByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User Id must be greater than 0");

            var list = await _applicantExperience.GetExperiencesByUserId(request.userId, cancellationToken);
            return _mapper.Map<List<ListWorkExperienceDTO>>(list);
        }
    }
}
