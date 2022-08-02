using ATS.Application.Contracts.Persistence.Applications;
using ATS.Domain.Models;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Commands.UpdateNote
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly INote _note;

        public UpdateNoteHandler(IMapper mapper, INote note)
        {
            _mapper = mapper;
            _note = note;
        }

        public async Task<bool> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _mapper.Map<Note>(request.updateNote);
            
            return await _note.UpdateAsync(note, cancellationToken);
        }
    }
}
