
namespace ATS.Application.DTO_s.Administration.Users
{
    public class CreateUserDTO : BaseUserDTO
    {
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
