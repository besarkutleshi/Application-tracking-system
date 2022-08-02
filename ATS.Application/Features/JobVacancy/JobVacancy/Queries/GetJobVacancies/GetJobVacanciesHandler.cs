using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancies
{
    public class GetJobVacanciesHandler : IRequestHandler<GetJobVacanciesQuery, List<ListJobDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IOpenJob _openJob;

        public GetJobVacanciesHandler(IMapper mapper, IOpenJob openJob)
        {
            _mapper = mapper;
            _openJob = openJob;
        }

        public async Task<List<ListJobDTO>> Handle(GetJobVacanciesQuery request, CancellationToken cancellationToken)
        {
            var list = await _openJob.GetListAsync(cancellationToken);
            return _mapper.Map<List<ListJobDTO>>(list);
        }
    }
}
