
namespace ATS.Application.DTO_s.Administration.Modules
{
    public class ModuleDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public int DisplaySequence { get; set; }
        public string Icon { get; set; } = string.Empty;
        public List<MenuItemDTO> Menus { get; set; }

        public ModuleDTO(List<MenuItemDTO> menus)
        {
            Menus = menus;
        }
    }
}
