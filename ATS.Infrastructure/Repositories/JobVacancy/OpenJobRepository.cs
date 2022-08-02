using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.JobVacancy
{
    public class OpenJobRepository : RepositoryBase<OpenJob>, IOpenJob
    {
        public OpenJobRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "OpenJobs")
        {

        }

        public override async Task<OpenJob> GetAsync(int id, CancellationToken token)
        {
            using (var con = _connection.CreateConnection())
            {
                var list = await con.QueryAsync<OpenJob, JobCategory, OpenJob>(new CommandDefinition(
                        $"SELECT * FROM dbo.OpenJobs AS oj INNER JOIN dbo.JobCategories AS jc ON jc.ID = oj.CategoryID WHERE oj.ID = {id}",
                        cancellationToken: token), (oj, jc) =>
                        {
                            oj.Category = jc;
                            return oj;
                        });
                return list.FirstOrDefault();
            }
        }

        public override async Task<List<OpenJob>> GetListAsync(CancellationToken token)
        {
            using (var con = _connection.CreateConnection())
            {
                var list = await con.QueryAsync<OpenJob, JobCategory, OpenJob>(new CommandDefinition(
                        "SELECT * FROM dbo.OpenJobs AS oj INNER JOIN dbo.JobCategories AS jc ON jc.ID = oj.CategoryID",
                        cancellationToken: token), (oj, jc) =>
                        {
                            oj.Category = jc;
                            return oj;
                        });
                return list.ToList();
            }
        }
    }
}
