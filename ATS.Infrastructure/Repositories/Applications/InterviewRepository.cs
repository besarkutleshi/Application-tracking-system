using ATS.Application.Contracts.Persistence.Applications;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infrastructure.Repositories.Applications
{
    public class InterviewRepository : RepositoryBase<Interview>, IInterview
    {
        public InterviewRepository(JobApplication_HRContext hRContext) : base(hRContext, "Interviews")
        {
        }

        public override async Task<List<Interview>> GetListAsync(CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var sqlQuery = "SELECT * FROM dbo.Interviews AS i " +
                    "INNER JOIN dbo.Applications AS a ON a.ID = i.ApplicationID " +
                    "INNER JOIN dbo.ApplicantProfile AS ap ON ap.ID = a.AplicantProfileID";
                var list = await conn.QueryAsync<Interview, ATS.Domain.Models.Application, ApplicantProfile, Interview>(
                    new CommandDefinition(sqlQuery, cancellationToken: token),
                    (i, a, ap) =>
                    {
                        a.AplicantProfile = ap;
                        i.Application = a;
                        return i;
                    });

                return list.ToList();
            }
        }

        public async Task<bool> ConfirmInterview(int interviewId, short value, CancellationToken token)
        {
            var interview = await _HRContext.Interviews.FirstOrDefaultAsync(a => a.Id == interviewId, token);

            if (interview is null) throw new Exception("Can not find Interview");
            if (interview.IsConfirmed != 0) throw new Exception("Interview is already confirmed");

            // -1 == Rejected
            // 0 == Pending
            // 1 == Confirmed
            interview.IsConfirmed = value;

            return await _HRContext.SaveChangesAsync() > 0;
        }
    }
}
