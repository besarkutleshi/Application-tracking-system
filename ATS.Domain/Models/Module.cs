using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Module
    {
        public Module()
        {
            Menus = new HashSet<Menu>();
            RoleModules = new HashSet<RoleModule>();
        }

        public int Id { get; set; }
        public string? ModuleName { get; set; }
        public int? DisplaySequence { get; set; }
        public short? IsActive { get; set; }
        public string? Icon { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
