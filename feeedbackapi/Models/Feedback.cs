using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Uname { get; set; } = null!;
        public string Review { get; set; } = null!;
        public int Rating { get; set; }

        public virtual FoodProduct PidNavigation { get; set; } = null!;
    }
}
