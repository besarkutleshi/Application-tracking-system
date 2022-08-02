using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Queries.GetCustomNotes
{
    public class GetCustomNotesHandler : IRequestHandler<GetCustomNotesQuery, List<ListNotesDTO>>
    {
        private readonly IMapper _mapper;
        private readonly INote _note;

        public GetCustomNotesHandler(IMapper mapper, INote note)
        {
            _mapper = mapper;
            _note = note;
        }

        public async Task<List<ListNotesDTO>> Handle(GetCustomNotesQuery request, CancellationToken cancellationToken)
        {
            var list = await _note.GetCustomNotesAsync(cancellationToken);

            return _mapper.Map<List<ListNotesDTO>>(list);
        }
    }
}
