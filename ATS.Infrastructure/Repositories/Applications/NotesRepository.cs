using ATS.Application.Contracts.Persistence.Applications;
using ATS.Domain.DapperModels;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;

namespace ATS.Infrastructure.Repositories.Applications
{
    public class NotesRepository : RepositoryBase<Note>, INote
    {
        public NotesRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "Notes")
        {

        }

        public async Task<List<Notes>> GetCustomNotesAsync(CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<Notes>(new CommandDefinition("SELECT * FROM dbo.vw_getAllNotes_New AS vgann", cancellationToken: token));

                return list.ToList();
            }
        }

        public async Task<List<Note>> GetNotesByApplicationId(int applicationId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var list = await conn.QueryAsync<Note>(
                    new CommandDefinition($"SELECT * FROM dbo.Notes AS n WHERE n.ApplicationID = {applicationId}", cancellationToken: token));

                return list.ToList();
            }
        }
    }
}
