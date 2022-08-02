using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetOffer
    {
        public DateTime? OfferExpire { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int Id { get; set; }
        public string ApplicationType { get; set; } = null!;
        public string ConfrimType { get; set; } = null!;
        public DateTime? ConfrimDate { get; set; }
        public string? Offer { get; set; }
    }
}
