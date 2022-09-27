using System;
using System.Collections.Generic;

namespace MiddleMVC.Models.DB
{
    public partial class Member
    {
        public Guid Memberid { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
