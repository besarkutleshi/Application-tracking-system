using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applicant
{
    public interface IApplicantSkill : IAsyncRepository<ApplicantSkill>
    {
        Task<List<ApplicantSkill>> GetApplicantSkillsByUserId(int userId, CancellationToken token);
    }
}
