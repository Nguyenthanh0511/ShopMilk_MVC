using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class WebsiteBanSua_LContext : DbContext
    {
        public WebsiteBanSua_LContext(DbContextOptions<WebsiteBanSua_LContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => new
            {
                p.Id,
            });
            modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany(p => p.products).HasForeignKey(p => p.CateId);

            modelBuilder.Entity<Image>().HasKey(I => new
            {
                I.Id,
            });
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(I => I.Images).HasForeignKey(IP => IP.ProdId);

            modelBuilder.Entity<CartDetail>().HasKey(CD => new
            {
                CD.UserId,
                CD.ProdId
            });
            modelBuilder.Entity<CartDetail>().HasOne(CD => CD.Product).WithMany(CD => CD.CartDetails).HasForeignKey(CD => CD.ProdId);
            modelBuilder.Entity<CartDetail>().HasOne(CD => CD.User).WithMany(CD => CD.CartDetails).HasForeignKey(CD => CD.UserId);

            modelBuilder.Entity<OrderDetail>().HasKey(CD => new
            {
                CD.OrId,
                CD.ProdId
            });
            modelBuilder.Entity<OrderDetail>().HasOne(CD => CD.Product).WithMany(CD => CD.OrderDetails).HasForeignKey(CD => CD.ProdId);
            modelBuilder.Entity<OrderDetail>().HasOne(CD => CD.Order).WithMany(CD => CD.OrderDetails).HasForeignKey(CD => CD.OrId);

            modelBuilder.Entity<Order>().HasKey(p => new
            {
                p.Id,
            });
            modelBuilder.Entity<Order>().HasOne(c => c.User).WithMany(p => p.Orders).HasForeignKey(p => p.UserId);
        }
        public DbSet<Category> categorys { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<CartDetail> cartsDetail { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
