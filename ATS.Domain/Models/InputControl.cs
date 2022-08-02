using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class InputControl
    {
        public int Id { get; set; }
        public int? ApplicationTypeId { get; set; }
        public string? InputName { get; set; }
        public short? IsRequired { get; set; }

        public virtual ApplicationType? ApplicationType { get; set; }
    }
}
