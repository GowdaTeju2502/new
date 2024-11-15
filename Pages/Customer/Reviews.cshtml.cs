using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_commerce.Database.Entity
{
    public class ReviewsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Public properties to bind form data
        public Electronic_Product Product { get; set; }
        [BindProperty]
        public string ReviewText { get; set; }
        [BindProperty]
        public int Rating { get; set; }

        public ReviewsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // OnGet method retrieves the order and product details
        public IActionResult OnGet(int orderedId)
        {
            var order = _context.Orders
                .Include(o => o.product)
                .FirstOrDefault(o => o.Order_Id == orderedId);

            if (order == null)
            {
                return RedirectToPage("/Customer/OrdersPage");
            }
            Product = order.product;

            return Page();
        }
        public IActionResult OnPost(int orderedId)
        {
            // Fetch the order details to validate the review
            var order = _context.Orders
                .Include(o => o.product)
                .FirstOrDefault(o => o.Order_Id == orderedId);

            if (order == null)
            {
                return RedirectToPage("/Customer/Orders");
            }

            // Retrieve the customer ID from the session
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (!customerId.HasValue)
            {
                return RedirectToPage("/Customer/Login");
            }

            var existingReview = _context.Reviews
                .FirstOrDefault(r => r.Product_Id == order.product.Product_Id && r.Customer_Id == customerId.Value);

            if (existingReview != null)
            {
                TempData["ErrorMessage"] = "You have already reviewed this product.";
                return RedirectToPage("/Customer/Orders");
            }

            // Create and save the new review
            var review = new Review
            {
                Product_Id = order.product.Product_Id,
                Review_Text = ReviewText,
                Rating = Rating,
                Customer_Id = customerId.Value,
                Review_Date = DateTime.Now
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Your review has been submitted successfully!";
            return RedirectToPage("/Customer/Orders");
        }

    }
}
