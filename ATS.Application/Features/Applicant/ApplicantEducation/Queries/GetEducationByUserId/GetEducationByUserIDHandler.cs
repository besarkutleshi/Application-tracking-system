using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Education;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Queries.GetEducationByUserId
{
    public class GetEducationByUserIDHandler : IRequestHandler<GetEducationByUserIdQuery, List<ListEducationDTO>>
    {
        private readonly IApplicantEducation _applicantEducation;
        private readonly IMapper _mapper;

        public GetEducationByUserIDHandler(IApplicantEducation applicantEducation, IMapper mapper)
        {
            _applicantEducation = applicantEducation;
            _mapper = mapper;
        }

        public async Task<List<ListEducationDTO>> Handle(GetEducationByUserIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _applicantEducation.GetEducationsByUserId(request.userId, cancellationToken);
            return _mapper.Map<List<ListEducationDTO>>(list);
        }
    }
}
