using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerce.Database
{
    public class CartPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // OnGet method to display the cart items
        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            // If the customer is not logged in, redirect to the login page
            if (!customerId.HasValue)
            {
                return RedirectToPage("/Customer/CustomerLoginPage");
            }

            // Retrieve the customer's cart items along with product details
            CartItems = _context.Carts
                .Where(c => c.Customer_Id == customerId.Value)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)  // Include related product details
                .SelectMany(c => c.CartItems)    // Flatten the cart items
                .ToList();

            if (!CartItems.Any())
            {
                TempData["Message"] = "Your cart is empty.";
            }

            return Page();
        }

        // OnPostAddToCart method to add items to the cart 
        public IActionResult OnPostAddToCart(int productId, int quantity)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");

            if (!customerId.HasValue)
            {
                return RedirectToPage("/Customer/CustomerLoginPage");
            }

            var customer = _context.Customers.FirstOrDefault(c => c.Customer_Id == customerId.Value);

            if (customer == null)
            {
                return RedirectToPage("/Customer/CustomerLoginPage");
            }

            var userCart = _context.Carts
                .Where(c => c.Customer_Id == customerId.Value)
                .Include(c => c.CartItems)  // Also include CartItems in case there are any
                .FirstOrDefault();

            if (userCart == null)
            {
                userCart = new Cart
                {
                    Customer_Id = customerId.Value
                };

                _context.Carts.Add(userCart);
                _context.SaveChanges();
            }

            // Check if the product is already in the cart
            var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.Product_Id == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity; // Update quantity if the item already exists
            }
            else
            {
                var cartItem = new CartItem
                {
                    Product_Id = productId,
                    Quantity = quantity,
                    Cart_Id = userCart.Cart_Id
                };

                userCart.CartItems.Add(cartItem);
            }

            _context.SaveChanges();

            return RedirectToPage("/Customer/CartPage");
        }
        public IActionResult OnPostUpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefault(ci => ci.CartItem_Id == cartItemId);

            if (cartItem != null && quantity > 0)
            {
                // Check if the quantity exceeds the available stock
                if (quantity > cartItem.Product.Product_Quantity)
                {
                    // Set the quantity to the maximum available stock
                    cartItem.Quantity = cartItem.Product.Product_Quantity;

                    //Optionally, you can set an error message or use TempData to notify the user
                    TempData["ErrorMessage"] = $"The quantity you requested exceeds the available stock. The quantity has been set to {cartItem.Product.Product_Quantity}.";
                }
                else
                {
                    // Update the quantity to the requested value
                    cartItem.Quantity = quantity;
                }

                // Save changes to the database
                _context.SaveChanges();
            }         
            return RedirectToPage();
        }

        // Remove item from cart
       public IActionResult OnPostRemoveFromCart(int cartItemId)
       {
            var cartItem = _context.CartItems
                .FirstOrDefault(ci => ci.CartItem_Id == cartItemId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToPage("/Customer/CartPage");
       }
    }
}
