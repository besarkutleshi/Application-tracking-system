using ATS.Application.Contracts.Persistence.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.DeleteJobResponsibility
{
    public class DeleteJobResponsibilityHandler : IRequestHandler<DeleteJobResponsibilityCommand, bool>
    {
        private readonly IJobResponsibility _jobResponsibility;

        public DeleteJobResponsibilityHandler(IJobResponsibility jobResponsibility)
        {
            _jobResponsibility = jobResponsibility;
        }

        public async Task<bool> Handle(DeleteJobResponsibilityCommand request, CancellationToken cancellationToken)
        {
            if (request.responsibilityId < 1) throw new Exception("Responsibility Id must be greater than 0");

            return await _jobResponsibility.DeleteAsync(request.responsibilityId, cancellationToken);
        }
    }
}
