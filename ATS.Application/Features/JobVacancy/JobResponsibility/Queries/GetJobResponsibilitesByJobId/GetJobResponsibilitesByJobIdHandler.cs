using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobResponsibility.Queries.GetJobResponsibilitesByJobId
{
    public class GetJobResponsibilitesByJobIdHandler : IRequestHandler<GetJobResponsibilitesByJobIdQuery, List<ListResponsibilityDTO>>
    {
        private readonly IJobResponsibility _jobResponsibility;
        private readonly IMapper _mapper;

        public GetJobResponsibilitesByJobIdHandler(IJobResponsibility jobResponsibility, IMapper mapper)
        {
            _jobResponsibility = jobResponsibility;
            _mapper = mapper;
        }

        public async Task<List<ListResponsibilityDTO>> Handle(GetJobResponsibilitesByJobIdQuery request, CancellationToken cancellationToken)
        {
            if (request.responsibilityId < 1) throw new Exception("Responsibility Id must be greater than 0");

            var responsibilites = await _jobResponsibility.GetJobsResponsibilitiesByJobIdAsync(request.responsibilityId, cancellationToken);
            return _mapper.Map<List<ListResponsibilityDTO>>(responsibilites);
        }
    }
}
