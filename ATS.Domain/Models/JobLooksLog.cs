using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class JobLooksLog
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public DateTime? Date { get; set; }

        public virtual OpenJob? Job { get; set; }
    }
}
