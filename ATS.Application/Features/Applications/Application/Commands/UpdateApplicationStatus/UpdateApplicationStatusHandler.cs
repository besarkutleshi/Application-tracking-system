using ATS.Application.Contracts.Persistence.Applications;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Commands.UpdateApplicationStatus
{
    public class UpdateApplicationStatusHandler : IRequestHandler<UpdateApplicationStatusCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IApplication _application;

        public UpdateApplicationStatusHandler(IMapper mapper, IApplication application)
        {
            _mapper = mapper;
            _application = application;
        }

        public async Task<bool> Handle(UpdateApplicationStatusCommand request, CancellationToken cancellationToken)
        {
            var application = _mapper.Map<ATS.Domain.Models.Application>(request.updateApplications);

            return await _application.UpdateAsync(application, cancellationToken);
        }
    }
}
