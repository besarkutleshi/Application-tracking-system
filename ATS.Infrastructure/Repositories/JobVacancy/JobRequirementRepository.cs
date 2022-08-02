using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.JobVacancy
{
    public class JobRequirementRepository : RepositoryBase<OpenJobsRequirement>, IJobRequirement
    {
        public JobRequirementRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "OpenJobsRequirements")
        {

        }

        public async Task<List<OpenJobsRequirement>> GetJobRequirementsByJobIdAsync(int jobId, CancellationToken token)
        {
            using (var con = _connection.CreateConnection())
            {
                var list = await con.QueryAsync<OpenJobsRequirement>(new CommandDefinition(
                        $"SELECT * FROM dbo.OpenJobsRequirements AS ojr WHERE ojr.JobID = {jobId}",
                        cancellationToken: token
                    ));
                return list.ToList();
            }
        }
    }
}
