using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancyById
{
    public class GetJobVacancyByIdHandler : IRequestHandler<GetJobVacancyByIdQuery, ListJobDTO>
    {
        private readonly IMapper _mapper;
        private readonly IOpenJob _openJob;

        public GetJobVacancyByIdHandler(IMapper mapper, IOpenJob openJob)
        {
            _mapper = mapper;
            _openJob = openJob;
        }

        public async Task<ListJobDTO> Handle(GetJobVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.jobId < 1) throw new Exception("Job Id must be greater than 0");

            var job = await _openJob.GetAsync(request.jobId, cancellationToken);
            return _mapper.Map<ListJobDTO>(job);
        }
    }
}
