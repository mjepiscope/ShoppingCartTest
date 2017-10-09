using Microsoft.EntityFrameworkCore;
using GlobalBlue.Models;

namespace GlobalBlue.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
            { }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Filename=GlobalBlue.Mvc\\GlobalBlue.db");
        // }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<HomeAddress> HomeAddress { get; set; }
        public DbSet<OfficeAddress> OfficeAddress { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}
