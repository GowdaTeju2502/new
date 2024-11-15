using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Http;  // For accessing session
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerce.Database.Entity
{
    public class SellerOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Injecting the database context through the constructor
        public SellerOrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; }  

        public string ErrorMessage { get; set; }  

        public decimal TotalAmount { get; set; }

        public void OnGet()
        {
            // Get SellerId from the session
            var sellerId = HttpContext.Session.GetInt32("SellerId");

            if (!sellerId.HasValue)
            {
                // If no SellerId in the session, redirect to login page
                RedirectToPage("/Seller/SellerLoginPage");
            }

            // Fetch orders where SellerId matches the logged-in seller
            Orders = _context.Orders
                .Where(o => o.Seller_Id == sellerId.Value)  // Filter by SellerId
                .Include(o => o.product)  // Include related Product details
                .Include(o => o.Customers) // Include related Customer details
                .ToList();

            // If no orders, show error message
            if (Orders == null || !Orders.Any())
            {
                ErrorMessage = "No orders found for your account.";
            }

            // Calculate total amount for the seller (optional)
            TotalAmount = Orders.Sum(order => order.Ordered_Quantity * order.product.Product_Price);
        }

    }
}
