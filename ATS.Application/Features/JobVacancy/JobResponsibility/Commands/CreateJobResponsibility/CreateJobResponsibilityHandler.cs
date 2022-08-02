using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Commands.CreateJobResponsibility
{
    public class CreateJobResponsibilityHandler : IRequestHandler<CreateJobResponsibilityCommand, CreateResponsibilityDTO>
    {
        private readonly IJobResponsibility _jobResponsibility;
        private readonly IMapper _mapper;

        public CreateJobResponsibilityHandler(IJobResponsibility jobResponsibility, IMapper mapper)
        {
            _jobResponsibility = jobResponsibility;
            _mapper = mapper;
        }

        public async Task<CreateResponsibilityDTO> Handle(CreateJobResponsibilityCommand request, CancellationToken cancellationToken)
        {
            var responsibility = _mapper.Map<ATS.Domain.Models.OpenJobsResponsibility>(request.createResponsibility);
            var jobResponsibility = await _jobResponsibility.AddAsync(responsibility, cancellationToken);
            return _mapper.Map<CreateResponsibilityDTO>(jobResponsibility);
        }
    }
}
