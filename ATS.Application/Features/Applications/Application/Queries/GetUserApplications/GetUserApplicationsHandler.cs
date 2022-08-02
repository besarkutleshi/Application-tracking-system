using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Application;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Queries.GetUserApplications
{
    public class GetUserApplicationsHandler : IRequestHandler<GetUserApplicationsQuery, List<ListApplicationsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IApplication _application;

        public GetUserApplicationsHandler(IMapper mapper, IApplication application)
        {
            _mapper = mapper;
            _application = application;
        }

        public async Task<List<ListApplicationsDTO>> Handle(GetUserApplicationsQuery request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User Id must be greater than 0");
            if (request.applicationTypeId < 1) throw new Exception("Application Type Id must be greater than 0");

            var list = await _application.GetUserApplications(request.userId, request.applicationTypeId, cancellationToken);
            return _mapper.Map<List<ListApplicationsDTO>>(list);
        }
    }
}
