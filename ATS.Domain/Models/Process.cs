using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Process
    {
        public Process()
        {
            MultiLanguages = new HashSet<MultiLanguage>();
        }

        public int Id { get; set; }
        public string? ProcessName { get; set; }

        public virtual ICollection<MultiLanguage> MultiLanguages { get; set; }
    }
}
