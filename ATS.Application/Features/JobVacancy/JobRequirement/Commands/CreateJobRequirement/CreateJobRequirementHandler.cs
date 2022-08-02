using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobRequirements;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.CreateJobRequirement
{
    public class CreateJobRequirementHandler : IRequestHandler<CreateJobRequirementCommand, CreateRequirementDTO>
    {
        private readonly IJobRequirement _jobRequirement;
        private readonly IMapper _mapper;

        public CreateJobRequirementHandler(IJobRequirement jobRequirement, IMapper mapper)
        {
            _jobRequirement = jobRequirement;
            _mapper = mapper;
        }

        public async Task<CreateRequirementDTO> Handle(CreateJobRequirementCommand request, CancellationToken cancellationToken)
        {
            var requirement = _mapper.Map<ATS.Domain.Models.OpenJobsRequirement>(request.createRequirement);
            var jobRequirement = await _jobRequirement.AddAsync(requirement, cancellationToken);
            return _mapper.Map<CreateRequirementDTO>(jobRequirement);
        }
    }
}
