using E_commerce.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace E_commerce.Database.context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Electronic_Product> Electronics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.Customer_Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.Cart_Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.Product_Id);


            modelBuilder.Entity<Order>()
            .HasOne(o => o.product)
            .WithMany()  // Assuming Product can have many orders
            .HasForeignKey(o => o.Product_Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customers)
                .WithMany()  // Assuming Customer can have many orders
                .HasForeignKey(o => o.Customer_Id);

            //modelBuilder.Entity<Electronic_Product>()
            ////.HasOne(ep => ep.Seller) // Each Electronic_Product has one Seller
            //.WithMany() // A Seller can have many Electronic_Products
            //.HasForeignKey(ep => ep.Seller_Id); // Foreign key is Seller_Id




        }


    }
}
