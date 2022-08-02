using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetAllNote
    {
        public int Id { get; set; }
        public string? NoteText { get; set; }
        public DateTime? NoteDate { get; set; }
        public string? FullName { get; set; }
        public string? JobTitle { get; set; }
        public string ApplicationType { get; set; } = null!;
        public DateTime? ApplicationDate { get; set; }
    }
}
