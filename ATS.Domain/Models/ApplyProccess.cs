using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplyProccess
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string? ApplyProccessDesc { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual OpenJob? Job { get; set; }
    }
}
