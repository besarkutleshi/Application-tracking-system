﻿using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class RoleModule
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }

        public virtual Module? Module { get; set; }
        public virtual Role? Role { get; set; }
    }
}
