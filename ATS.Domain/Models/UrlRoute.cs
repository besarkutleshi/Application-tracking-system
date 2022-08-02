using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class UrlRoute
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string? Url { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
