using ATS.Application.Contracts.Persistence.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Commands.UpdateJobVacancy
{
    public class UpdateJobVacancyHandler : IRequestHandler<UpdateJobVacancyCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOpenJob _openJob;

        public UpdateJobVacancyHandler(IMapper mapper, IOpenJob openJob)
        {
            _mapper = mapper;
            _openJob = openJob;
        }

        public async Task<bool> Handle(UpdateJobVacancyCommand request, CancellationToken cancellationToken)
        {
            var job = _mapper.Map<ATS.Domain.Models.OpenJob>(request.updateJob);
            return await _openJob.UpdateAsync(job, cancellationToken);
        }
    }
}
