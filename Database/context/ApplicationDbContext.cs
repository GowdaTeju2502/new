using E_commerce.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace E_commerce.Database.context
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
          public DbSet<Cart> Carts { get; set; }
          public DbSet<Customer> Customers {  get; set; }
          public DbSet<Electronic_Product> Electronics { get; set; }
          public DbSet<Order> Orders { get; set; }
          public DbSet<Seller>Sellers { get; set; }

    }
}
