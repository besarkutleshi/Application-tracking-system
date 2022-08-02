using ATS.Application.DTO_s.Administration.Applications.Application;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Commands.UpdateApplicationStatus
{
    public record UpdateApplicationStatusCommand(UpdateApplicationsDTO updateApplications) : IRequest<bool>;
}
