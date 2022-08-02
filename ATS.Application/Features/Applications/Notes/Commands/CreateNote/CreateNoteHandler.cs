using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications;
using ATS.Domain.Models;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Commands.CreateNote
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, CreateNoteDTO>
    {
        private readonly INote _note;
        private readonly IMapper _mapper;

        public CreateNoteHandler(INote note, IMapper mapper)
        {
            _note = note;
            _mapper = mapper;
        }

        public async Task<CreateNoteDTO> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _mapper.Map<Note>(request.createNote);
            var noteObj = await _note.AddAsync(note, cancellationToken);

            return _mapper.Map<CreateNoteDTO>(noteObj);
        }
    }
}
