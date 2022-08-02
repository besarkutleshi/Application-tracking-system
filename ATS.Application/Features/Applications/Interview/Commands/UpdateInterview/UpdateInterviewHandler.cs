using ATS.Application.Contracts.Persistence.Applications;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.UpdateInterview
{
    public class UpdateInterviewHandler : IRequestHandler<UpdateInterviewCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IInterview _interview;

        public UpdateInterviewHandler(IMapper mapper, IInterview interview)
        {
            _mapper = mapper;
            _interview = interview;
        }

        public async Task<bool> Handle(UpdateInterviewCommand request, CancellationToken cancellationToken)
        {
            var interview = _mapper.Map<ATS.Domain.Models.Interview>(request.update);

            return await _interview.UpdateAsync(interview, cancellationToken);
        }
    }
}
