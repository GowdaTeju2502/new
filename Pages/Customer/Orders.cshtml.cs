using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerce.Database.Entity
{
    public class OrdersPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Order> Orders { get; set; }

        public OrdersPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Get the CustomerId from the session
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            // If no CustomerId is found in the session, redirect to the login page
            if (!customerId.HasValue)
            {
                return RedirectToPage("/Customer/CustomerLoginPage");
            }

            // Fetch the customer's orders by CustomerId
            Orders = _context.Orders
                .Where(o => o.Customer_Id == customerId.Value)  // Use CustomerId instead of email
                .Include(o => o.product)  // Include product details
                .OrderByDescending(o => o.Ordered_Date)  // Order by most recent first
                .ToList();

            return Page();
        }
    }
}
