using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleModules = new HashSet<RoleModule>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual ICollection<RoleModule> RoleModules { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
