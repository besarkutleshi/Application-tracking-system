using ATS.Application.DTO_s.Administration.Applications;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Queries.GetCustomNotes
{
    public record GetCustomNotesQuery() : IRequest<List<ListNotesDTO>>;
}
