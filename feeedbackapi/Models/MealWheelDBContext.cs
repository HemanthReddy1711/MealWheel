using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace feeedbackapi.Models
{
    public partial class MealWheelDBContext : DbContext
    {
        //public MealWheelDBContext()
        //{
        //}

        public MealWheelDBContext(DbContextOptions<MealWheelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Billing> Billings { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<FoodProduct> FoodProducts { get; set; } = null!;
        public virtual DbSet<MyOrder> MyOrders { get; set; } = null!;
        public virtual DbSet<MyProfile> MyProfiles { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=tcp:healthplusconsultation.database.windows.net,1433;Initial Catalog=MealWheelDB;Persist Security Info=False;User ID=hemanth;Password=Healthplus@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoorNo).HasColumnName("Door_no");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Firstname).HasMaxLength(250);

                entity.Property(e => e.Lastname).HasMaxLength(250);

                entity.Property(e => e.MobileNumber).HasMaxLength(10);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Profileurl).HasColumnName("profileurl");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("billings");

                entity.HasIndex(e => e.Pid, "IX_billings_pid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOrdered).HasColumnName("dateOrdered");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.Pid);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");

                entity.HasIndex(e => e.Pid, "IX_carts_pid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Pid);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("favorites");

                entity.HasIndex(e => e.Pid, "IX_favorites_pid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Pid);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedbacks");

                entity.HasIndex(e => e.Pid, "IX_feedbacks_pid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Uname).HasColumnName("uname");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.Pid);
            });

            modelBuilder.Entity<FoodProduct>(entity =>
            {
                entity.ToTable("Food_Products");

                entity.HasIndex(e => e.Cid, "IX_Food_Products_cid");

                entity.Property(e => e.AddressRes).HasColumnName("address_res");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Fav)
                    .IsRequired()
                    .HasColumnName("fav")
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Picurl).HasColumnName("picurl");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.FoodProducts)
                    .HasForeignKey(d => d.Cid);
            });

            modelBuilder.Entity<MyOrder>(entity =>
            {
                entity.ToTable("myOrders");

                entity.HasIndex(e => e.Bid, "IX_myOrders_bid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.BidNavigation)
                    .WithMany(p => p.MyOrders)
                    .HasForeignKey(d => d.Bid);
            });

            modelBuilder.Entity<MyProfile>(entity =>
            {
                entity.ToTable("myProfiles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Profileurl).HasColumnName("profileurl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
