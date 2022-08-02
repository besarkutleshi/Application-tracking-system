using ATS.Application.Contracts.Persistence.Applications;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applications
{
    public class QuestionRepository : IQuestion
    {
        protected readonly DbConnection _connection;

        public QuestionRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<AplicantQuestion>> GetApplicationQuestions(int applicationId, CancellationToken cancellation)
        {
            using (var conn = _connection.CreateConnection())
            {
                string sqlQuery = 
                    "SELECT * FROM dbo.AplicantQuestions AS aq " +
                    "INNER JOIN dbo.ApplicantProfile AS ap ON ap.ID = aq.AplicantProfileID " +
                    $"INNER JOIN dbo.Questions AS q ON q.ID = aq.QuestionID WHERE aq.ApplicationID = {applicationId}";
                var list = await conn.QueryAsync<AplicantQuestion, ApplicantProfile, Question, AplicantQuestion>(
                    new CommandDefinition(sqlQuery, cancellationToken: cancellation), (aq, ap, q) =>
                    {
                        aq.AplicantProfile = ap;
                        aq.Question = q;
                        return aq;
                    });
                return list.ToList();
            }
        }

        public async Task<List<Question>> GetQuestion(CancellationToken cancellation)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<Question>(new CommandDefinition("SELECT * FROM dbo.Questions AS q", cancellationToken: cancellation));
                return list.ToList();
            }
        }
    }
}
