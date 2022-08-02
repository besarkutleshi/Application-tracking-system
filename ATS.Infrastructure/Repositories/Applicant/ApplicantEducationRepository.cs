using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applicant
{
    public class ApplicantEducationRepository : RepositoryBase<ApplicantEducation>, IApplicantEducation
    {
        public ApplicantEducationRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "ApplicantEducation")
        {

        }

        public async Task<bool> AddEducationCertificate(ApplicantCertificate applicantCertificate, CancellationToken token)
        {
            await _HRContext.ApplicantCertificates.AddAsync(applicantCertificate, token);
            return await _HRContext.SaveChangesAsync() > 0;
        }

        public async Task<string> DeleteEducationCertificate(int educationId, CancellationToken token)
        {
            var certificate = await _HRContext.ApplicantCertificates.FirstOrDefaultAsync(ac => ac.ApplicantEducationId == educationId);
            if (certificate == null) throw new Exception("Certificate not found.");

            _HRContext.ApplicantCertificates.Remove(certificate);
            var deleted = await _HRContext.SaveChangesAsync();
            if (deleted > 0)
            {
                return certificate.CertificateName;
            }
            return null;
        }

        public async Task<List<ApplicantEducation>> GetEducationsByUserId(int userId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<ApplicantEducation, ApplicantCertificate, ApplicantEducation>(new CommandDefinition(
                    $"SELECT * FROM dbo.ApplicantEducation AS ae LEFT JOIN dbo.ApplicantCertificates AS ac ON ac.ApplicantEducationID = ae.ID WHERE ae.UserID = {userId}", 
                    cancellationToken: token), (ae, ac ) =>
                {
                    ae.ApplicantCertificates.Add(ac);
                    return ae;
                });
                return list.ToList();
            }
        }
    }
}
