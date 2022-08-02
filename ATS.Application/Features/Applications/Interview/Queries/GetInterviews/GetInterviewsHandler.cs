using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Interview;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Queries.GetInterviews
{
    public class GetInterviewsHandler : IRequestHandler<GetInterviewsQuery, List<ListInterviewsDTO>>
    {
        private readonly IInterview interview;
        private readonly IMapper _mapper;

        public GetInterviewsHandler(IInterview interview, IMapper mapper)
        {
            this.interview = interview;
            _mapper = mapper;
        }

        public async Task<List<ListInterviewsDTO>> Handle(GetInterviewsQuery request, CancellationToken cancellationToken)
        {
            var list = await interview.GetListAsync(cancellationToken);

            return _mapper.Map<List<ListInterviewsDTO>>(list);
        }
    }
}
