using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Http;  // Add this for accessing session
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace E_commerce.Database.Entity
{
    public class SellerLoginPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject context
        public SellerLoginPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }  // For displaying login error

        // Page Load (GET) Method
        public void OnGet()
        {
        }

        // Handle login POST request
        public IActionResult OnPostLogin()
        {
            var authUser = _context.Sellers
                .FirstOrDefault(p => p.Seller_Email == Email && p.Seller_Password == Password);

            // Check if the user exists and the credentials match
            if (authUser != null)
            {
                // Store the SellerId in the session after successful login
                HttpContext.Session.SetInt32("SellerId", authUser.Seller_Id);

                // Successful login, redirect to the Seller Products page
                return RedirectToPage("/Seller/SellerProducts");
            }

            // Invalid credentials
            ErrorMessage = "Invalid email or password.";
            return Page();
        }

        // Handle signup POST request (registration of new seller)
        public IActionResult OnPostSignup()
        {
            // Check if the seller already exists in the database
            var existingSeller = _context.Sellers
                .FirstOrDefault(s => s.Seller_Email == Email);

            if (existingSeller != null)
            {
                ErrorMessage = "Email already exists. Please log in.";
                return Page();
            }

            var newSeller = new Seller
            {
                Seller_Email = Email,
                Seller_Password = Password // Store plain text password (not recommended for production)
            };

            _context.Add(newSeller);
            _context.SaveChanges();

            // Redirect to login page after successful signup
            return RedirectToPage("/Seller/SellerLoginPage");
        }
    }
}
