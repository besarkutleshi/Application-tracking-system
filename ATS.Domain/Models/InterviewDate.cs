using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class InterviewDate
    {
        public int Id { get; set; }
        public int? InterviewId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Interview? Interview { get; set; }
    }
}
