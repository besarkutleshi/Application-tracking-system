using ATS.Application.DTO_s.Administration.Applications.Application;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Commands.CreateApplication
{
    public record CreateApplicationCommand(CreateApplicationDTO createApplication) : IRequest<CreateApplicationDTO>;
}
