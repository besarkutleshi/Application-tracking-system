using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetCategory
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
        public string? Category { get; set; }
        public string? CategoryAlbania { get; set; }
        public string? Departament { get; set; }
        public string? Division { get; set; }
    }
}
