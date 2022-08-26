using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Billing
    {
        public Billing()
        {
            MyOrders = new HashSet<MyOrder>();
        }

        public int Id { get; set; }
        public bool Orderplaced { get; set; }
        public int Quantity { get; set; }
        public int Pid { get; set; }
        public DateTime DateOrdered { get; set; }

        public virtual FoodProduct PidNavigation { get; set; } = null!;
        public virtual ICollection<MyOrder> MyOrders { get; set; }
    }
}
