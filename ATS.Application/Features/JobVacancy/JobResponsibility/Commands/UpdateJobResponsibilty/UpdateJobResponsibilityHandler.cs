using ATS.Application.Contracts.Persistence.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.UpdateJobResponsibilty
{
    public class UpdateJobResponsibilityHandler : IRequestHandler<UpdateJobResponsibilityCommand, bool>
    {
        private readonly IJobResponsibility _jobResponsibility;
        private readonly IMapper _mapper;

        public UpdateJobResponsibilityHandler(IJobResponsibility jobResponsibility, IMapper mapper)
        {
            _jobResponsibility = jobResponsibility;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateJobResponsibilityCommand request, CancellationToken cancellationToken)
        {
            var responsibility = _mapper.Map<ATS.Domain.Models.OpenJobsResponsibility>(request.updateResponsibility);
            return await _jobResponsibility.UpdateAsync(responsibility, cancellationToken);
        }
    }
}
