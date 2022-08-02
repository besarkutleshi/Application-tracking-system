using MediatR;

namespace ATS.Application.Features.Applications.Notes.Commands.DeleteNote
{
    public record DeleteNoteCommand(int id) : IRequest<bool>;
}
