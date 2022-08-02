using ATS.Application.DTO_s.Administration.Applications;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Queries.GetNotesByApplicationId
{
    public record GetNotesByApplicationIdQuery(int applicationId) : IRequest<List<ListApplicationNoteDTO>>;
}
