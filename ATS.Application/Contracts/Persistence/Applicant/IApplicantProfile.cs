using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applicant
{
    public interface IApplicantProfile : IAsyncRepository<ApplicantProfile>
    {
        Task<bool> InsertImage(int profileId, string photoName, CancellationToken token);
    }
}
