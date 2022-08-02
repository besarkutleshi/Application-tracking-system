using ATS.Application.DTO_s.Administration.Authentication;
using ATS.Application.DTO_s.Administration.Modules;
using MediatR;

namespace ATS.Application.Features.Administration.Module.Queries
{
    public record GetModulesQuery(LoginResponseDTO loginResponse) : IRequest<List<ModuleDTO>>;
}
