using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
