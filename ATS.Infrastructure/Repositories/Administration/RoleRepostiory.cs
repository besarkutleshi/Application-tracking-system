using ATS.Application.Contracts.Persistence.Administration;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infrastructure.Repositories.Administration
{
    public class RoleRepostiory : RepositoryBase<Role>, IRole
    {
        public RoleRepostiory(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "Roles")
        {

        }

        public async Task<bool> AddRolesInRole(int roleId, List<UserRole> usersInRole, CancellationToken token)
        {
            try
            {
                await _HRContext.Database.BeginTransactionAsync(token);

                var roles = await _HRContext.UserRoles.Where(ur => ur.RoleId == roleId).ToListAsync();

                _HRContext.UserRoles.RemoveRange(roles);

                if (usersInRole.Count == 0)
                {
                    await _HRContext.Database.CommitTransactionAsync(token);
                    return true;
                }

                await _HRContext.UserRoles.AddRangeAsync(usersInRole);

                if (await _HRContext.SaveChangesAsync(token) > 0)
                {
                    await _HRContext.Database.CommitTransactionAsync(token);
                    return true;
                }

                await _HRContext.Database.RollbackTransactionAsync(token);
                return false;
            }
            catch (Exception)
            {
                await _HRContext.Database.RollbackTransactionAsync(token);
                throw;
            }
        }

        public async Task<List<UserRole>> GetUsersInRole(int roleId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var usersInRole = await conn.QueryAsync<UserRole, User, UserRole>(
                        new CommandDefinition($"SELECT * FROM dbo.UserRoles AS ur INNER JOIN dbo.Users AS u ON u.ID = ur.UserID WHERE ur.RoleID = {roleId}",
                            cancellationToken: token), (ur, u) =>
                            {
                                ur.User = u;
                                return ur;
                            }
                        );
                return usersInRole.ToList();
            }
        }
    }
}
