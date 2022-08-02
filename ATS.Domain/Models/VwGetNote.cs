using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetNote
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public int? ApplicationId { get; set; }
    }
}
