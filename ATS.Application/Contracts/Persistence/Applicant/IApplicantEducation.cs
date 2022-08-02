using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applicant
{
    public interface IApplicantEducation : IAsyncRepository<ApplicantEducation>
    {
        Task<string> DeleteEducationCertificate(int educationId, CancellationToken token);
        Task<bool> AddEducationCertificate(ApplicantCertificate applicantCertificate, CancellationToken token);
        Task<List<ApplicantEducation>> GetEducationsByUserId(int userId, CancellationToken token);
    }
}
