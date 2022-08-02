using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Application.DTO_s.Administration.Modules
{
    public class MenuItemDTO
    {
		public int Id { get; set; }
		public int ModuleId { get; set; }
		public string MenuName { get; set; }
		public int? DisplaySequence { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }
		public int IsShown { get; set; }
		public string ComponentName { get; set; }
		public string Layout { get; set; }
        public string UrlRoute { get; set; }

        public List<MenuItemDTO> SubMenus;

		public MenuItemDTO()
		{
			SubMenus = new List<MenuItemDTO>();
		}
	}
}
