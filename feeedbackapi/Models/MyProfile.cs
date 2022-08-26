using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class MyProfile
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string? Profileurl { get; set; }
        public string Email { get; set; } = null!;
    }
}
