
namespace ATS.Application.DTO_s.Administration.Authentication
{
    public class ResetPasswordDTO
    {
        public string Username { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
