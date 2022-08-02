using ATS.Application.DTO_s.Administration.Roles;
using ATS.Application.DTO_s.Administration.Users;

namespace ATS.Application.DTO_s.Administration.UserRole
{
    public class ListUserRoleDTO : BaseUserRoleDTO
    {
        public ListUserRoleDTO(ListUserDTO user, ListRolesDTO role)
        {
            User = user;
            Role = role;
        }

        public ListUserDTO User { get; set; }
        public ListRolesDTO Role { get; set; }

    }
}
