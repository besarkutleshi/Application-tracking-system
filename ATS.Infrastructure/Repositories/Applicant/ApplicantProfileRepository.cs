using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infrastructure.Repositories.Applicant
{
    public class ApplicantProfileRepository : RepositoryBase<ATS.Domain.Models.ApplicantProfile>, IApplicantProfile
    {
        public ApplicantProfileRepository(JobApplication_HRContext jobApplication_HR)
            :base(jobApplication_HR, "ApplicantProfile")
        {

        }

        public async Task<bool> InsertImage(int profileId, string photoName, CancellationToken token)
        {
            var profile = await _HRContext.ApplicantProfiles.FirstOrDefaultAsync(ap => ap.Id == profileId, token);
            if(profile == null)
            {
                throw new Exception("Not found!");
            }
            profile.Photo = photoName;
            return await _HRContext.SaveChangesAsync(token) > 0;
        }

        public override async Task<Domain.Models.ApplicantProfile> GetAsync(int id, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var result = await conn.QueryAsync<Domain.Models.ApplicantProfile>(
                    new CommandDefinition($"Select * from ApplicantProfile as t where t.UserID = {id}", cancellationToken: token));
                return result.FirstOrDefault();
            }
        }
    }
}
