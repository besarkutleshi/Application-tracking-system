using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobRequirements;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Queries.GetJobRequirementsByJobId
{
    public class GetRequirementsByJobIdHandler : IRequestHandler<GetRequirementsByJobIdQuery, List<ListRequirementsDTO>>
    {
        private readonly IJobRequirement _jobRequirement;
        private readonly IMapper _mapper;

        public GetRequirementsByJobIdHandler(IJobRequirement jobRequirement, IMapper mapper)
        {
            _jobRequirement = jobRequirement;
            _mapper = mapper;
        }

        public async Task<List<ListRequirementsDTO>> Handle(GetRequirementsByJobIdQuery request, CancellationToken cancellationToken)
        {
            if (request.jobId < 1) throw new Exception("Job Id must be greater than 0");

            var requirements = await _jobRequirement.GetJobRequirementsByJobIdAsync(request.jobId, cancellationToken);
            return _mapper.Map<List<ListRequirementsDTO>>(requirements);
        }
    }
}
