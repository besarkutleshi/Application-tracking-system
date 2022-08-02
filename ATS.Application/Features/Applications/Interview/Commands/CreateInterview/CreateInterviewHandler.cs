using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Interview;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.CreateInterview
{
    public class CreateInterviewHandler : IRequestHandler<CreateInterviewCommand, CreateInterviewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IInterview _interview;

        public CreateInterviewHandler(IMapper mapper, IInterview interview)
        {
            _mapper = mapper;
            _interview = interview;
        }

        public async Task<CreateInterviewDTO> Handle(CreateInterviewCommand request, CancellationToken cancellationToken)
        {
            var interview = _mapper.Map<ATS.Domain.Models.Interview>(request.createInterview);

            var model = await _interview.AddAsync(interview, cancellationToken);

            return _mapper.Map<CreateInterviewDTO>(model);
        }
    }
}
