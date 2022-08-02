using ATS.Application.DTO_s.Administration.UserRole;

namespace ATS.Application.DTO_s.Administration.Roles
{
    public class CreateRoleDTO : BaseRoleDTO
    {
        public List<CreateUserRoleDTO> UserRoles { get; set; }

        public CreateRoleDTO(List<CreateUserRoleDTO> userRoles)
        {
            UserRoles = userRoles;
        }

        public int InsertBy { get; set; }
        public DateTime InsertDate { get; } = DateTime.Now;
    }
}
