using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Application;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Commands.CreateApplication
{
    public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, CreateApplicationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplication _application;

        public CreateApplicationHandler(IMapper mapper, IApplication application)
        {
            _mapper = mapper;
            _application = application;
        }

        public async Task<CreateApplicationDTO> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = _mapper.Map<ATS.Domain.Models.Application>(request.createApplication);
            var model = await _application.AddAsync(application, cancellationToken);

            return _mapper.Map<CreateApplicationDTO>(model);    
        }
    }
}
