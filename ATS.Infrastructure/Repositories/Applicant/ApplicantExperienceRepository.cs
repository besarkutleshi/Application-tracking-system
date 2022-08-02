using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applicant
{
    public class ApplicantExperienceRepository : RepositoryBase<ApplicantWorkExperience>, IApplicantExperience
    {
        public ApplicantExperienceRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "ApplicantWorkExperience")
        {

        }

        public async Task<string> DeleteExperienceCertificate(int experienceId, CancellationToken token)
        {
            string fileName = "";
            var experience = await _HRContext.ApplicantWorkExperiences.FirstOrDefaultAsync(exp => exp.Id == experienceId, token);
            if (experience == null) throw new Exception("Experience not found.");

            fileName = experience.FileName;
            experience.FileName = null;

            await _HRContext.SaveChangesAsync(token);

            return fileName;
        }

        public async Task<List<ApplicantWorkExperience>> GetExperiencesByUserId(int userId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var report = await conn.QueryAsync<ApplicantWorkExperience>(
                    new CommandDefinition($"Select * from ApplicantWorkExperience as awe where as.UserId = {userId}", cancellationToken: token));
                return report.ToList();
            }
        }
    }
}
