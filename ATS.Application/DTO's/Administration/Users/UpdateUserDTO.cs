
namespace ATS.Application.DTO_s.Administration.Users
{
    public class UpdateUserDTO : BaseUserDTO
    {
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
