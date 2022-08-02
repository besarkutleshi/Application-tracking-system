namespace ATS.Application.DTO_s.Administration.Authentication
{
    public class ChangePasswordDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
