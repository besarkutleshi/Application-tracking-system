using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.JobVacancy
{
    public class JobResponsibilityRepository : RepositoryBase<OpenJobsResponsibility>, IJobResponsibility
    {
        public JobResponsibilityRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "OpenJobsResponsibility")
        {

        }

        public async Task<List<OpenJobsResponsibility>> GetJobsResponsibilitiesByJobIdAsync(int jobId, CancellationToken cancellationToken)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<OpenJobsResponsibility>(new CommandDefinition(
                        $"SELECT * FROM dbo.OpenJobsResponsibility AS ojr WHERE ojr.JobID = {jobId}",
                        cancellationToken: cancellationToken
                    ));
                return list.ToList();
            }
        }
    }
}
