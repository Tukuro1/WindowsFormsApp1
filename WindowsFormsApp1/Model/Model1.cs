using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);
        }
    }
}
