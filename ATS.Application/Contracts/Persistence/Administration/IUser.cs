using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Administration
{
    public interface IUser : IAsyncRepository<User>
    {
        Task<bool> AddUserRoles(int userId, List<UserRole> roles, CancellationToken token);
        Task<List<UserRole>> GetUserRoles(int userId, CancellationToken token);
        Task<User> GetUserByUsernameAsync(string username, CancellationToken token);
    }
}
