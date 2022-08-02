using ATS.Domain.DapperModels;
using ATS.Domain.Models;

namespace ATS.Application.Contracts.Persistence.Administration
{
    public interface IAuthentication
    {
        Task<LoginResponse> Login(User user, CancellationToken token);
        Task<bool> ChangePassword(User user, string newPassword, CancellationToken token);

        // this return bool because after registering user should confirm his email
        Task<User?> RegisterUser(User user, CancellationToken token);

        Task<bool> ConfirmEmail(int userId, string email, CancellationToken cancellationToken);
        Task<bool> ResetPassword(string email, string newPassword, CancellationToken token);
    }
}
