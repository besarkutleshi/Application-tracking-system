using ATS.Application.DTO_s.Administration.Applications.Application;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Queries.GetUserApplications
{
    public record GetUserApplicationsQuery(int userId, int applicationTypeId) : IRequest<List<ListApplicationsDTO>>;
}
