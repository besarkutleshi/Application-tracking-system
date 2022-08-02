using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.JobVacancy
{
    public interface IJobRequirement : IAsyncRepository<OpenJobsRequirement>
    {
        Task<List<OpenJobsRequirement>> GetJobRequirementsByJobIdAsync(int jobId, CancellationToken token);
    }
}
