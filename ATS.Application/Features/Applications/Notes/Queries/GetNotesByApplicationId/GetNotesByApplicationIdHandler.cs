using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Notes.Queries.GetNotesByApplicationId
{
    public class GetNotesByApplicationIdHandler : IRequestHandler<GetNotesByApplicationIdQuery, List<ListApplicationNoteDTO>>
    {
        private readonly IMapper _mapper;
        private readonly INote _note;

        public GetNotesByApplicationIdHandler(IMapper mapper, INote note)
        {
            _mapper = mapper;
            _note = note;
        }

        public async Task<List<ListApplicationNoteDTO>> Handle(GetNotesByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            if (request.applicationId < 1) throw new Exception("Application Id must be greater than 0");

            var list = await _note.GetNotesByApplicationId(request.applicationId, cancellationToken);

            return _mapper.Map<List<ListApplicationNoteDTO>>(list);
        }
    }
}
