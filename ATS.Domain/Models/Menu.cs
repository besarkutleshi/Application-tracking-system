using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
            UrlRoutes = new HashSet<UrlRoute>();
        }

        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public string? MenuName { get; set; }
        public int? ParentId { get; set; }
        public int? DisplaySequence { get; set; }
        public short? IsActive { get; set; }
        public string? Icon { get; set; }
        public short? IsShown { get; set; }
        public string? ComponentName { get; set; }
        public string? Layout { get; set; }
        public string? UrlRoute { get; set; }

        public virtual Module? Module { get; set; }
        public virtual Menu? Parent { get; set; }
        public virtual ICollection<Menu> InverseParent { get; set; }
        public virtual ICollection<UrlRoute> UrlRoutes { get; set; }
    }
}
