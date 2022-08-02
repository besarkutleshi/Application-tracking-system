using ATS.Application.Contracts.Persistence.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobRequirement.Commands.DeleteJobRequirement
{
    public class DeleteJobRequirementHandler : IRequestHandler<DeleteJobRequirementCommand, bool>
    {
        private readonly IJobRequirement _jobRequirement;

        public DeleteJobRequirementHandler(IJobRequirement jobRequirement)
        {
            _jobRequirement = jobRequirement;
        }

        public async Task<bool> Handle(DeleteJobRequirementCommand request, CancellationToken cancellationToken)
        {
            if (request.jobRequirementId < 1) throw new Exception("Requirement Id must be greater than 0");
            return await _jobRequirement.DeleteAsync(request.jobRequirementId, cancellationToken);
        }
    }
}
