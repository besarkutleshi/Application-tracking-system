using ATS.Application.DTO_s.Administration.Applications;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Commands.CreateNote
{
    public record CreateNoteCommand(CreateNoteDTO createNote) : IRequest<CreateNoteDTO>;
}
