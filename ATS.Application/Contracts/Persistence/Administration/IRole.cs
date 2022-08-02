using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Administration
{
    public interface IRole : IAsyncRepository<Role>
    {
        Task<List<UserRole>> GetUsersInRole(int roleId, CancellationToken token);
        Task<bool> AddRolesInRole(int roleId, List<UserRole> usersInRole, CancellationToken token);
    }
}
