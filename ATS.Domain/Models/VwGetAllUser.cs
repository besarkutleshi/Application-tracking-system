using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetAllUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public short? IsActive { get; set; }
    }
}
