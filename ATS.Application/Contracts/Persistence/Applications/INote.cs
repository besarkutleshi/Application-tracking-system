using ATS.Domain.DapperModels;
using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Applications
{
    public interface INote : IAsyncRepository<Note>
    {
        Task<List<Note>> GetNotesByApplicationId(int applicationId, CancellationToken token);
        Task<List<Notes>> GetCustomNotesAsync(CancellationToken token);
    }
}
