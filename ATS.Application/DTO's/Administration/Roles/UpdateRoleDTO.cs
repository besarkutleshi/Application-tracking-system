using ATS.Application.DTO_s.Administration.UserRole;

namespace ATS.Application.DTO_s.Administration.Roles
{
    public class UpdateRoleDTO : BaseRoleDTO
    {
        public List<CreateUserRoleDTO> UserRoles { get; set; }

        public UpdateRoleDTO(List<CreateUserRoleDTO> userRoles)
        {
            UserRoles = userRoles;
        }

        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; } = DateTime.Now;
    }
}
