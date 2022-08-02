using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Application;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Queries.GetApplications
{
    public class GetApplicationsHandler : IRequestHandler<GetApplicationsQuery, List<ListApplicationsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IApplication _application;

        public GetApplicationsHandler(IMapper mapper, IApplication application)
        {
            _mapper = mapper;
            _application = application;
        }

        public async Task<List<ListApplicationsDTO>> Handle(GetApplicationsQuery request, CancellationToken cancellationToken)
        {
            var list = await _application.GetListAsync(cancellationToken);

            return _mapper.Map<List<ListApplicationsDTO>>(list);
        }
    }
}
