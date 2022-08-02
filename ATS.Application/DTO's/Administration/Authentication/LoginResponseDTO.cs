using ATS.Application.DTO_s.Administration.Modules;
using ATS.Application.DTO_s.Administration.Roles;

namespace ATS.Application.DTO_s.Administration.Authentication
{
    public class LoginResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }

        public List<ListRolesDTO>? Roles { get; set; }
        public List<ModuleDTO>? Modules { get; set; }
    }
}
