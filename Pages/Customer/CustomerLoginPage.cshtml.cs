using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce.Database.Entity;
using System.ComponentModel.DataAnnotations;
using E_commerce.Database.context;

namespace E_commerce.Database
{
    public class CustomerLoginPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please enter your email or phone number.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        private readonly ApplicationDbContext _context;

        public CustomerLoginPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login handler
        public IActionResult OnPost()
        {
            // Clear previous error message if any
            ErrorMessage = string.Empty;

            // Fetch user from the database by email
            var user = _context.Customers.FirstOrDefault(c => c.Customer_Email == Email);

            if (user!=null)
            {
                HttpContext.Session.SetInt32("CustomerId",user.Customer_Id);

                return RedirectToPage("/Customer/CustomerViewPage");
                // Invalid credentials
                //ErrorMessage = "Invalid email or password.";
                //return Page();
            }

            // Successful login, redirect to the customer view page
            ErrorMessage = "Invalid email or password.";
            return Page();
        }

        // Signup handler (Optional)
        public IActionResult OnPostSignup()
        {
            // Clear previous error message if any
            ErrorMessage = string.Empty;

            // Check if the email already exists in the database
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Customer_Email == Email);

            if (existingCustomer != null)
            {
                // Email already exists
                ErrorMessage = "Email already exists. Please log in.";
                return Page();
            }

            // Create a new customer (without password hashing)
            var newCustomer = new Customer
            {
                Customer_Email = Email,
                Customer_Password = Password  // Store the plain-text password
            };

            _context.Add(newCustomer);
            _context.SaveChanges();

            // Redirect to login page after successful signup
            return RedirectToPage("/Customer/CustomerLoginPage");
        }

        public void OnGet()
        {

        }
    }
}
