using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applicant
{
    public class ApplicantSkillsRepository : RepositoryBase<ApplicantSkill>, IApplicantSkill
    {
        public ApplicantSkillsRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "ApplicantSkills")
        {

        }

        public async Task<List<ApplicantSkill>> GetApplicantSkillsByUserId(int userId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var report = await conn.QueryAsync<ApplicantSkill>(
                    new CommandDefinition($"Select * from ApplicantSkill as awe where as.UserId = {userId}", cancellationToken: token));
                return report.ToList();
            }
        }
    }
}
