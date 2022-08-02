
namespace ATS.Application.DTO_s.Administration.UserRole
{
    public abstract class BaseUserRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int IsChecked { get; set; }
    }
}
