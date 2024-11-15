using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce.Database.Entity;
using E_commerce.Database.context;

namespace E_commerce.Database
{
    public class CustomerHomePageModel : PageModel
    {
        [BindProperty]
        public Customer Customers { get; set; }
        public void OnGet()
        {

        }
        private readonly ApplicationDbContext _context;
        public CustomerHomePageModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnPostSignup()

        {
            var newCustomer = new Customer
            {
                Customer_Email = Customers.Customer_Email,
                Customer_Password = Customers.Customer_Password,
                Customer_Address = Customers.Customer_Address,
                Customer_ConfirmPassword = Customers.Customer_ConfirmPassword,
                Customer_Contact = Customers.Customer_Contact,
                Customer_District = Customers.Customer_District,
                Customer_DOB = Customers.Customer_DOB,
                Customer_Gender = Customers.Customer_Gender,
                Customer_Id = Customers.Customer_Id,
               
                Customer_Landmark = Customers.Customer_Landmark,
                Customer_Name = Customers.Customer_Name,    
                Customer_Pincode = Customers.Customer_Pincode,
                Customer_State = Customers.Customer_State,
            };
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            
            if (ModelState.IsValid)
            {
                return RedirectToPage("CustomerLoginPage");
            }
            return RedirectToPage("/Customer/CustomerRegisterPage");
        }
    }
}
