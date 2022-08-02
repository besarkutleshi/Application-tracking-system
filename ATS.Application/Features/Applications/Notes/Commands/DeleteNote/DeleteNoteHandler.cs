using ATS.Application.Contracts.Persistence.Applications;
using MediatR;
namespace ATS.Application.Features.Applications.Notes.Commands.DeleteNote
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, bool>
    {
        private readonly INote _note;

        public DeleteNoteHandler(INote note)
        {
            _note = note;
        }

        public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("Note Id must be greater than 0");

            return await _note.DeleteAsync(request.id, cancellationToken);
        }
    }
}
