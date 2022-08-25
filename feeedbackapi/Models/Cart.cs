using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public int TotalPrice { get; set; }
        public string Uname { get; set; } = null!;

        public virtual FoodProduct PidNavigation { get; set; } = null!;
    }
}
