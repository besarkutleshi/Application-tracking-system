using ATS.Application.Contracts.Persistence.Administration;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infrastructure.Repositories.Administration
{
    public class UserRepository : RepositoryBase<User>, IUser
    {
        public UserRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "Users")
        {

        }

        public override async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            var user = await _HRContext.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (user == null) throw new Exception("Can not find user");

            user.IsActive = 0;
            return await _HRContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUserRoles(int userId, List<UserRole> roles, CancellationToken token)
        {
            try
            {
                await _HRContext.Database.BeginTransactionAsync(token);

                var userRoles = await _HRContext.UserRoles.Where(ur => ur.UserId == userId).ToListAsync(token);

                if(userRoles.Any()) _HRContext.UserRoles.RemoveRange(userRoles);

                if (!roles.Any())
                {
                    await _HRContext.Database.CommitTransactionAsync(token);
                    return true;
                }

                await _HRContext.UserRoles.AddRangeAsync(roles, token);
                if(await _HRContext.SaveChangesAsync(token) > 0)
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

        public async Task<List<UserRole>> GetUserRoles(int userId, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var userRoles = await conn.QueryAsync<UserRole, User, UserRole>(
                    new CommandDefinition($"SELECT * FROM dbo.UserRoles AS ur INNER JOIN dbo.Users AS u ON u.ID = ur.UserID WHERE ur.UserID = {userId}",
                    cancellationToken: token), (ur, u) =>
                    {
                        ur.User = u;
                        return ur;
                    });
                return userRoles.ToList();
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username, CancellationToken token)
        {
            var user = await _HRContext.Users.FirstOrDefaultAsync(x => x.Username == username, token);
            if (user == null) throw new Exception("Can not find user");

            return user;
        }
    }
}
