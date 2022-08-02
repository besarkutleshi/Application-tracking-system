using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.JobVacancy
{
    public interface IJobResponsibility : IAsyncRepository<OpenJobsResponsibility>
    {
        Task<List<OpenJobsResponsibility>> GetJobsResponsibilitiesByJobIdAsync(int jobId, CancellationToken cancellationToken);
    }
}
