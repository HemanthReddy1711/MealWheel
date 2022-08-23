using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealWheel.Models
{
    public class Meal
    {
    }

    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Food_Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [ForeignKey("category")]
        [DisplayName("category Name")]
        public int cid { get; set; }

        public category category { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
        public string address_res { get; set; }
        public bool Avail { get; set; }
        public int quantity { get; set; }
        [NotMapped]
        public IFormFile pic { get; set; }

        public string picurl { get; set; }
    }

    public class feedback
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int pid { get; set; }
        public Food_Products product { get; set; }
        public string uname { get; set; }
        public string review { get; set; }
        public int rating { get; set; }
    }

    public class favorite
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int pid { get; set; }

        public Food_Products product { get; set; }

        public string uname { get; set; }

    }

    public class discount
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }
    public class Billing
    {
        public int id { get; set; }

        public bool Orderplaced { get; set; }

        public int quantity { get; set; }

        [ForeignKey("product")]
        public int pid { get; set; }
        public Food_Products product { get; set; }

        public DateTime dateOrdered { get; set; }
    }
    public class MyOrder
    {
        public int id { get; set; }
        [ForeignKey("bill")]
        public int bid { get; set; }
        public Billing bill { get; set; }

        public string uname { get; set; }

    }

    public class Cart
    {
        public int id { get; set; }
        [ForeignKey("product")]
        public int pid { get; set; }

        public Food_Products product { get; set; }
        public int totalPrice { get; set; }

        public string uname { get; set; }
    }

    public class MyProfile
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string? profileurl { get; set; }
        [NotMapped]
        public IFormFile profileImage { get; set; }
    }

    public class Address
    {
        public int id { get; set; }
        public string Door_no { get; set; }
        public string  Area { get; set; }

        public string uname { get; set; }

        public string Landmark { get; set; }
        public string FullAddress { get; set; }
    }

    public class MealDbContext : DbContext
    {
        public MealDbContext(DbContextOptions<MealDbContext> options) : base(options) { }
        public DbSet<Food_Products> Food_Products { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<feedback> feedbacks { get; set; }
        public DbSet<favorite> favorites { get; set; }
        public DbSet<discount> discounts { get; set; }
        public DbSet<MyOrder> myOrders { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Billing> billings { get; set; }
        public DbSet<MyProfile> myProfiles { get; set; }
        public DbSet<Address> addresses { get; set; }
    }
}
