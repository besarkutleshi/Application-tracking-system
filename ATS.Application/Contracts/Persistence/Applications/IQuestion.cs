using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applications
{
    public interface IQuestion
    {
        Task<List<Question>> GetQuestion(CancellationToken cancellation);
        Task<List<AplicantQuestion>> GetApplicationQuestions(int applicationId, CancellationToken cancellation);
    }
}
