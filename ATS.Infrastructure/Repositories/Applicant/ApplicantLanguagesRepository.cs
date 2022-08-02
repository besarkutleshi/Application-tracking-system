using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applicant
{
    public class ApplicantLanguagesRepository : RepositoryBase<ApplicantLanguage>, IApplicantLanguage
    {
        public ApplicantLanguagesRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "ApplicantLanguages")
        {

        }

        public async Task<List<ApplicantLanguage>> GetApplicantLanguagesByUserId(int userId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var report = await conn.QueryAsync<ApplicantLanguage>(
                    new CommandDefinition($"Select * from ApplicantWorkExperience as awe where as.UserId = {userId}", cancellationToken: token));
                return report.ToList();
            }
        }
    }
}
