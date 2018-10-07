using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Default") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Product)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasIndex(a => a.Status)
               .HasName("IX_Status");

            modelBuilder.Entity<Order>().HasIndex(a => a.BankGetNumber)
              .HasName("IX_BankGetNumber");

            modelBuilder.Entity<Order>().HasIndex(a => a.BankTransNumber)
              .HasName("IX_BankTransNumber");

            modelBuilder.Entity<Order>().HasIndex(a => a.PostBarCode)
              .HasName("IX_PostBarCode");

            modelBuilder.Entity<Prices>().HasIndex(a => a.Date)
             .HasName("IX_Date");

            modelBuilder.Entity<Product>().HasIndex(a => a.Title)
             .HasName("IX_TitleFa");

            modelBuilder.Entity<Product>().HasIndex(a => a.Date)
            .HasName("IX_Date");

            modelBuilder.Entity<Product>().HasIndex(a => a.Status)
            .HasName("IX_Status");
            
        }

        public DbSet<Servers> Servers { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
