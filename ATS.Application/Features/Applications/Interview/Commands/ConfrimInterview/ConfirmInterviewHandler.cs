using ATS.Application.Contracts.Persistence.Applications;
using MediatR;

namespace ATS.Application.Features.Applications.Interview.Commands.ConfrimInterview
{
    public class ConfirmInterviewHandler : IRequestHandler<ConfirmInterviewCommand, bool>
    {
        private readonly IInterview _interview;

        public ConfirmInterviewHandler(IInterview interview)
        {
            _interview = interview;
        }

        public async Task<bool> Handle(ConfirmInterviewCommand request, CancellationToken cancellationToken)
        {
            if (request.interviewId < 1) throw new Exception("Interview Id must be greater than 0");
            if (request.value < -1 || request.value > 1) throw new Exception("Confirm value must be between -1 and 1");

            return await _interview.ConfirmInterview(request.interviewId, request.value, cancellationToken);
        }
    }
}
