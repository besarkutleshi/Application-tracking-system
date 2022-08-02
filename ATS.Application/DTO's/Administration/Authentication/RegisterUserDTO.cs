namespace ATS.Application.DTO_s.Administration.Authentication
{
    public class RegisterUserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

        private DateTime? InsertDate { get; } = DateTime.Now;
    }
}
