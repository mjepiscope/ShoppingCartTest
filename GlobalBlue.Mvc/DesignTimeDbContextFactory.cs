using System.IO;
using GlobalBlue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GlobalBlue.Mvc
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingCartContext>
    {
        public ShoppingCartContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ShoppingCartContext>();
            builder.UseSqlite("Data Source=GlobalBlue.db", b => b.MigrationsAssembly("GlobalBlue.Mvc"));
            return new ShoppingCartContext(builder.Options);
        }
    }
}