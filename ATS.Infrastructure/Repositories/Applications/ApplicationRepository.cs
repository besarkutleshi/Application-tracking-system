using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Application;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applications
{
    public class ApplicationRepository : RepositoryBase<ATS.Domain.Models.Application>, IApplication
    {
        private string sqlQuery = "SELECT * FROM dbo.Applications AS a " +
                    "INNER JOIN dbo.ApplicantProfile AS ap ON ap.ID = a.AplicantProfileID " +
                    "INNER JOIN dbo.OpenJobs AS oj ON oj.ID = a.OpenJobID " +
                    "INNER JOIN dbo.JobCategories AS jc ON jc.ID = a.CategoryID";

        public ApplicationRepository(JobApplication_HRContext hRContext) 
            : base(hRContext, "Applications")
        {
        }

        public override async Task<List<Domain.Models.Application>> GetListAsync(CancellationToken token)
        {
            return await GetApplications(token);
        }

        public async Task<List<Domain.Models.Application>> GetUserApplications(int userId, int applicationTypeId, CancellationToken token)
        {
            sqlQuery += $" WHERE a.UserID = {userId} AND a.ApplicationTypeID = {applicationTypeId};";
            return await GetApplications(token);
        }

        private async Task<List<Domain.Models.Application>> GetApplications(CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<Domain.Models.Application, ApplicantProfile, OpenJob, JobCategory, Domain.Models.Application>
                    (new CommandDefinition(sqlQuery, cancellationToken: token),
                    (a, ap, o, jc) =>
                    {
                        a.AplicantProfile = ap;
                        a.OpenJob = o;
                        a.Category = jc;
                        return a;
                    });

                return list.ToList();
            }
        }
    }
}
