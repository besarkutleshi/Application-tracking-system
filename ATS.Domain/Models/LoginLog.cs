using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class LoginLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }

        public virtual User? User { get; set; }
    }
}
