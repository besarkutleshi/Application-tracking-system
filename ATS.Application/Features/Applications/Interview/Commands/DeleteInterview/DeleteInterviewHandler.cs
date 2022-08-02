using ATS.Application.Contracts.Persistence.Applications;
using MediatR;
namespace ATS.Application.Features.Applications.Interview.Commands.DeleteInterview
{
    public class DeleteInterviewHandler : IRequestHandler<DeleteInterviewCommand, bool>
    {
        private readonly IInterview _interview;

        public DeleteInterviewHandler(IInterview interview)
        {
            _interview = interview;
        }

        public async Task<bool> Handle(DeleteInterviewCommand request, CancellationToken cancellationToken)
        {
            if (request.id < 1) throw new Exception("Interview Id must be greater than 0");

            return await _interview.DeleteAsync(request.id, cancellationToken);
        }
    }
}
