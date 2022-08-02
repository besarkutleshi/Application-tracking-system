using ATS.Application.Contracts.Persistence.Administration;
using ATS.Domain.DapperModels;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ATS.Infrastructure.Repositories.Administration
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly JobApplication_HRContext _HRContext;
        private readonly DbConnection _connection;

        public AuthenticationRepository()
        {
            _HRContext = new JobApplication_HRContext();
            _connection = new DbConnection();
        }

        public async Task<bool> ChangePassword(User user, string newPassword, CancellationToken token)
        {
            var model = await _HRContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id && u.Username == user.Username, token);
            if (model is null) throw new Exception("User does not exists");

            model.Password = newPassword;

            return await _HRContext.SaveChangesAsync(token) > 0;
        }

        public async Task<bool> ConfirmEmail(int userId, string email, CancellationToken cancellationToken)
        {
            var model = await _HRContext.Users.FirstOrDefaultAsync(u => u.Username == email && u.Id == userId, cancellationToken);
            if (model is null) throw new Exception("User does not exists");

            model.IsConfirmed = 1;

            return await _HRContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<LoginResponse> Login(User user, CancellationToken token)
        {
            var paramenters = new DynamicParameters();
            paramenters.Add("username", user.Username, DbType.String, ParameterDirection.Input);
            paramenters.Add("password", user.Password, DbType.String, ParameterDirection.Input);

            using (var con = _connection.CreateConnection())
            {

                var result = await con.QueryMultipleAsync(
                    new CommandDefinition("usp_Login", paramenters, commandType: CommandType.StoredProcedure, cancellationToken: token));

                User usr = null;
                try
                {
                    usr = result.Read<User>().FirstOrDefault();
                }
                catch (Exception)
                {
                    throw new Exception("Email or password was incorrect");
                }

                var roles = result.Read<Role>().ToList();
                var modules = result.Read<Module>().ToList();
                var menus = result.Read<Menu>().ToList();

                foreach (var item in modules)
                {
                    var moduleMenus = menus.Where(e => e.ModuleId == item.Id).ToList();
                    if (moduleMenus.Any())
                    {
                        item.Menus = moduleMenus;
                    }
                }

                return new LoginResponse
                {
                    Id = usr.Id,
                    Username = usr.Username,
                    Roles = roles,
                    Modules = modules
                };

                //var sqlString = $"SELECT * FROM dbo.Users AS u INNER JOIN dbo.UserRoles AS ur ON ur.UserID = u.ID INNER JOIN dbo.Roles AS r ON r.ID = ur.RoleID WHERE u.Username = '{user.Username}' AND u.Password = '{user.Password}'";

                //var result = await con.QueryAsync<User, UserRole, Role, User>(
                //    new CommandDefinition(sqlString, cancellationToken: token), (u, ur, r) =>
                //    {
                //        ur.Role = r;
                //        u.UserRoles.Add(ur);
                //        return u;
                //    });

                //return result.First();

                //model.UserRoles.First().Role.role
            }
        }

        public async Task<User?> RegisterUser(User user, CancellationToken token)
        {
            var role = await _HRContext.Roles.FirstOrDefaultAsync(r => r.Id == 2, token);
            if (role is null) throw new Exception("Role Applicant is not found");

            user.UserRoles.Add(new UserRole { Role = role });
            user.IsConfirmed = 0;
            var entity = await _HRContext.Users.AddAsync(user, token);

            return await _HRContext.SaveChangesAsync(token) > 0 ? entity.Entity : null;
        }

        public async Task<bool> ResetPassword(string email, string newPassword, CancellationToken token)
        {
            var model = await _HRContext.Users.FirstOrDefaultAsync(u => u.Username == email, token);
            if (model is null) throw new Exception("User does not exists");

            model.Password = newPassword;

            return await _HRContext.SaveChangesAsync(token) > 0;
        }
    }
}
