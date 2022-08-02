using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applicant
{
    public interface IApplicantLanguage : IAsyncRepository<ApplicantLanguage>
    {
        Task<List<ApplicantLanguage>> GetApplicantLanguagesByUserId(int userId, CancellationToken token);
    }
}
