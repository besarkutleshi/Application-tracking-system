using ATS.Application.Contracts.Persistence.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.UpdateJobRequirement
{
    public class UpdateJobRequirementHandler : IRequestHandler<UpdateJobRequirementCommand, bool>
    {
        private readonly IJobRequirement _jobRequirement;
        private readonly IMapper _mapper;

        public UpdateJobRequirementHandler(IJobRequirement jobRequirement, IMapper mapper)
        {
            _jobRequirement = jobRequirement;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateJobRequirementCommand request, CancellationToken cancellationToken)
        {
            var jobRequirement = _mapper.Map<ATS.Domain.Models.OpenJobsRequirement>(request);
            return await _jobRequirement.UpdateAsync(jobRequirement, cancellationToken);
        }
    }
}
