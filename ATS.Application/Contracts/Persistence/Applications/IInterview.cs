using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applications
{
    public interface IInterview : IAsyncRepository<Interview>
    {
        Task<bool> ConfirmInterview(int interviewId, short value, CancellationToken token);
    }
}
