using ATS.Application.DTO_s.Administration.Applications.Application;

namespace ATS.Application.Contracts.Persistence.Applications
{
    public interface IApplication : IAsyncRepository<ATS.Domain.Models.Application>
    {
        Task<List<Domain.Models.Application>> GetUserApplications(int userId, int applicationTypeId, CancellationToken token);
    }
}
