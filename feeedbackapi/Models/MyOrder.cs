using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class MyOrder
    {
        public int Id { get; set; }
        public int Bid { get; set; }
        public string Uname { get; set; } = null!;

        public virtual Billing BidNavigation { get; set; } = null!;
    }
}
