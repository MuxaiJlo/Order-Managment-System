using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Managment_System
{
    internal class OrderDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OrderDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
               .HasOne(o => o.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.Customer_ID)
               .OnDelete(DeleteBehavior.Cascade); // Выберите нужное вам правило удаления

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.Order_ID)
                .OnDelete(DeleteBehavior.Cascade); // Выберите нужное вам правило удаления

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.Product_ID)
                .OnDelete(DeleteBehavior.Cascade);

           

            base.OnModelCreating(modelBuilder);
        }

        public void OpenConnection()
        {
            Database.OpenConnection();
        }

        public void CloseConnection()
        {
            Database.CloseConnection();
        }
    }
}
