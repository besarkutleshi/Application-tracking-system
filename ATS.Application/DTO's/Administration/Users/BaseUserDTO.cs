
namespace ATS.Application.DTO_s.Administration.Users
{
    public abstract class BaseUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int EmpId { get; set; }
    }
}
