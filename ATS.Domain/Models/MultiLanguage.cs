using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class MultiLanguage
    {
        public int Id { get; set; }
        public int? ProcessId { get; set; }
        public int? TableProcessId { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }

        public virtual Process? Process { get; set; }
    }
}
