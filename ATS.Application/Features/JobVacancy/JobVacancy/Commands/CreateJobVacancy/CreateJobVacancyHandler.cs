using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.CreateJobVacancy
{
    public class CreateJobVacancyHandler : IRequestHandler<CreateJobVacancyCommand, CreateJobDTO>
    {
        private readonly IMapper _mapper;
        private readonly IOpenJob _openJob;

        public CreateJobVacancyHandler(IMapper mapper, IOpenJob openJob)
        {
            _mapper = mapper;
            _openJob = openJob;
        }

        public async Task<CreateJobDTO> Handle(CreateJobVacancyCommand request, CancellationToken cancellationToken)
        {
            var openJob = _mapper.Map<ATS.Domain.Models.OpenJob>(request.createJob);
            var job = await _openJob.AddAsync(openJob, cancellationToken);
            return _mapper.Map<CreateJobDTO>(job);  
        }
    }
}
