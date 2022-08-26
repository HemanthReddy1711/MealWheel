using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string DoorNo { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Landmark { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public string Uname { get; set; } = null!;
    }
}
