using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applicant
{
    public interface IApplicantExperience : IAsyncRepository<ApplicantWorkExperience>
    {
        Task<string> DeleteExperienceCertificate(int experienceId, CancellationToken token);
        Task<List<ApplicantWorkExperience>> GetExperiencesByUserId(int userId, CancellationToken token);
    }
}
