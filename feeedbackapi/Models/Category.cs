using System;
using System.Collections.Generic;

namespace feeedbackapi.Models
{
    public partial class Category
    {
        public Category()
        {
            FoodProducts = new HashSet<FoodProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<FoodProduct> FoodProducts { get; set; }
    }
}
