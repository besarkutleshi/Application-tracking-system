using ATS.Application.DTO_s.Administration.Authentication;

namespace ATS.Application.Contracts.Infrastructure
{
    public interface IToken
    {
        string GenerateToken(LoginResponseDTO loginResponse);
        ConfirmEmailTokenResponseDTO? ValidateToken(string token);
        string GenerateTokenEmailConfirmation(int userId, string email);
    }
}
