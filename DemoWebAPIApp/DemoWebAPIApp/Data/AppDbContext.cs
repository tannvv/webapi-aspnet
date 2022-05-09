using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(order => order.OrderID);
                entity.Property(order => order.OrderDate).HasDefaultValueSql("getutcdate()");
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(entity => new { entity.OrderID, entity.ProductID });
                entity.HasOne(e => e.Order)
                    .WithMany(or => or.OrderDetails)
                    .HasForeignKey(e => e.OrderID)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(e => e.Product)
                    .WithMany(or => or.OrderDetails)
                    .HasForeignKey(e => e.ProductID)
                    .HasConstraintName("FK_OrderDetail_Product");
            });
        }
    }
}
