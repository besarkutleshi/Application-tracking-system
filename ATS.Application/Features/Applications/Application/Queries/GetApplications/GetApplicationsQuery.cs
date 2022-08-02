using ATS.Application.DTO_s.Administration.Applications.Application;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Queries.GetApplications
{
    public record GetApplicationsQuery() : IRequest<List<ListApplicationsDTO>>;
}
