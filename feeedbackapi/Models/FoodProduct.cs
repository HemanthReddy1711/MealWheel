using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class FoodProduct
    {
        public FoodProduct()
        {
            Billings = new HashSet<Billing>();
            Carts = new HashSet<Cart>();
            Favorites = new HashSet<Favorite>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Cid { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; } = null!;
        public string AddressRes { get; set; } = null!;
        public bool Avail { get; set; }
        public int Quantity { get; set; }
        public string Picurl { get; set; } = null!;
        public bool? Fav { get; set; }

        public virtual Category CidNavigation { get; set; } = null!;
        public virtual ICollection<Billing> Billings { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
