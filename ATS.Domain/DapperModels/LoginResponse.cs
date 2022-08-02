using ATS.Domain.Models;

namespace ATS.Domain.DapperModels
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public List<Role>? Roles { get; set; }
        public List<Module>? Modules { get; set; }
    }
}
