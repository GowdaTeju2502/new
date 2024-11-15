
using E_commerce.Database.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace E_commerce.Database.Entity
{
    public class CheckoutPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Order CheckoutOrder { get; set; }

        public List<CartItem> CartItems { get; set; }

        public string ErrorMessage { get; set; }
        public decimal TotalAmount { get; set; }

        public CheckoutPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Get the CustomerId from the session
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (!customerId.HasValue)
            {
                RedirectToPage("/Customer/Login");
                return;
            }

            CartItems = _context.Carts
                .Where(c => c.Customer_Id == customerId.Value) 
                .SelectMany(c => c.CartItems)
                .Include(ci => ci.Product)
                .ToList();

            if (CartItems != null && CartItems.Any())
            {
                TotalAmount = CartItems.Sum(item =>
                {
                    if (item.Product == null)
                    {
                        Console.WriteLine($"Product is null for CartItem ID: {item.CartItem_Id}");
                    }
                    return item.Product != null ? item.Quantity * item.Product.Product_Price : 0;
                });
            }
            else
            {
                TotalAmount = 0;
                ErrorMessage = "Your cart is empty.";
            }
        }

        public IActionResult OnPost()
        {
            // Get the CustomerId from the session
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (!customerId.HasValue)
            {
                return RedirectToPage("/Customer/Login");
            }

            var customer = _context.Customers.FirstOrDefault(c => c.Customer_Id == customerId.Value);
            if (customer == null)
            {
                return RedirectToPage("/Customer/Login");
            }

            var cartItems = _context.Carts
                .Where(c => c.Customer_Id == customerId.Value) // Use CustomerId from session
                .SelectMany(c => c.CartItems)
                .Include(ci => ci.Product)
                .ToList();

            List<Order> orders = new List<Order>();
            bool outOfStock = false;

            foreach (var cartItem in cartItems)
            {
                if (cartItem.Product == null || cartItem.Product.Product_Quantity < cartItem.Quantity)
                {
                    outOfStock = true;
                    ErrorMessage = $"Sorry, {cartItem.Product.Product_Name} is out of stock or insufficient quantity.";
                    break;
                }

                var order = new Order
                {
                    Ordered_Date = DateTime.Now,
                    Product_Id = cartItem.Product_Id,
                    Customer_Id = customer.Customer_Id,  
                    Ordered_Quantity = cartItem.Quantity,
                    Seller_Id = cartItem.Product.Seller_Id

                };


                cartItem.Product.Product_Quantity -= cartItem.Quantity;

                _context.Orders.Add(order);
                orders.Add(order);  
            }

            if (outOfStock)
            {
                return Page(); 
            }

    
            _context.SaveChanges();

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();

   
            TempData["OrderDetails"] = "Your order has been placed successfully! Thank you for shopping.";

            return RedirectToPage("/Customer/OrderConfirmation");
        }
    }
}
