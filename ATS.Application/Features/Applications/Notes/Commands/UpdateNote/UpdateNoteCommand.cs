using ATS.Application.DTO_s.Administration.Applications;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Commands.UpdateNote
{
    public record UpdateNoteCommand(UpdateNoteDTO updateNote) : IRequest<bool>;
}
