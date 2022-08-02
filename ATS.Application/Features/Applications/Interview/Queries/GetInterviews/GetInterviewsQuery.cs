using ATS.Application.DTO_s.Administration.Applications.Interview;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Queries.GetInterviews
{
    public record GetInterviewsQuery() : IRequest<List<ListInterviewsDTO>>;
}
