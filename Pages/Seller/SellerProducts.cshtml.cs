//using E_commerce.Database.context;
//using E_commerce.Database.Entity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Hosting;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;// For accessing session

//namespace E_commerce.Database.Entity
//{
//    public class SellerProductsModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IWebHostEnvironment _environment;

//        public SellerProductsModel(ApplicationDbContext context, IWebHostEnvironment environment)
//        {
//            _context = context;
//            _environment = environment;
//        }

//        [BindProperty]
//        public Electronic_Product Electronic_Products { get; set; }

//        public IFormFile ImageFile { get; set; }

//        // For displaying the list of products (optional)
//        public IQueryable<Electronic_Product> Products { get; set; }

//        public void OnGet()
//        {
//            Products = _context.Electronics
//                .Include(ep => ep.Seller_Id)  
//                .AsQueryable();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            var sellerId = HttpContext.Session.GetInt32("SellerId");

//            if (sellerId == null)
//            {
//                return RedirectToPage("/Seller/SellerLoginPage");
//            }

//            if (Electronic_Products.ImageFile != null)
//            {
//                var filename = Guid.NewGuid().ToString() + Path.GetExtension(Electronic_Products.ImageFile.FileName);
//                var filepath = Path.Combine(_environment.WebRootPath, "Upload", filename);
//                var filestream = new FileStream(filepath, FileMode.Create);

//                // Copy image file to the server
//                await Electronic_Products.ImageFile.CopyToAsync(filestream);

//                // Create a new product
//                var newProduct = new Electronic_Product
//                {
//                    Product_Name = Electronic_Products.Product_Name,
//                    Product_Description = Electronic_Products.Product_Description,
//                    Product_Price = Electronic_Products.Product_Price,
//                    Product_Quantity = Electronic_Products.Product_Quantity,
//                    Battery_capacity = Electronic_Products.Battery_capacity,
//                    Brand = Electronic_Products.Brand,
//                    Operating_System = Electronic_Products.Operating_System,
//                    RAM = Electronic_Products.RAM,
//                    ROM = Electronic_Products.ROM,
//                    Ratings = Electronic_Products.Ratings,
//                    Seller_Id = sellerId.Value,  // Assign SellerId from session
//                    Seller_Name = Electronic_Products.Seller_Name,
//                    ImagePath = $"Upload/{filename}"
//                };

//                // Add the product to the database
//                _context.Electronics.Add(newProduct);
//                await _context.SaveChangesAsync();

//                return RedirectToPage("/Seller/SellerProductDisplay");
//            }

//            return Page(); // If no image is uploaded, return to the same page
//        }
//    }
//}
using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Database.Entity
{
    public class SellerProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SellerProductsModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Electronic_Product Electronic_Products { get; set; }

        public IFormFile ImageFile { get; set; }

        // For displaying the list of products
        public IQueryable<Electronic_Product> Products { get; set; }

        // For editing the product quantity
        [BindProperty]
        public int NewQuantity { get; set; }

        // OnGet method to load products for the logged-in seller
        public void OnGet()
        {
            var sellerId = HttpContext.Session.GetInt32("SellerId");

            if (sellerId != null)
            {
                // Get all products of the logged-in seller
                Products = _context.Electronics
                    .Where(ep => ep.Seller_Id == sellerId.Value)
                    .AsQueryable();
            }
            else
            {
                RedirectToPage("/Seller/SellerLoginPage"); // Redirect to login if no session
            }
        }

        // OnPost method to update the quantity of a specific product
        public async Task<IActionResult> OnPostUpdateQuantityAsync(int productId)
        {
            var sellerId = HttpContext.Session.GetInt32("SellerId");

            if (sellerId == null)
            {
                return RedirectToPage("/Seller/SellerLoginPage"); // If no session, redirect to login
            }

            // Find the product by ID and check if it belongs to the logged-in seller
            var productToUpdate = await _context.Electronics
                .Where(ep => ep.Product_Id == productId && ep.Seller_Id == sellerId.Value)
                .FirstOrDefaultAsync();

            if (productToUpdate == null)
            {
                // Product not found or doesn't belong to the seller
                return RedirectToPage("/Seller/SellerProductDisplay"); // Redirect if not authorized
            }

            // Update the product quantity
            productToUpdate.Product_Quantity = NewQuantity;

            // Save the updated product
            await _context.SaveChangesAsync();

            // Redirect to product display page
            return RedirectToPage("/Seller/SellerProductDisplay");
        }

        // OnPost method to add a new product
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the SellerId from the session
            var sellerId = HttpContext.Session.GetInt32("SellerId");

            // Check if the session contains a valid SellerId
            if (sellerId == null)
            {
                // If no SellerId found in session, redirect to login page
                return RedirectToPage("/Seller/SellerLoginPage");
            }

            if (Electronic_Products.ImageFile != null)
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(Electronic_Products.ImageFile.FileName);
                var filepath = Path.Combine(_environment.WebRootPath, "Upload", filename);
                var filestream = new FileStream(filepath, FileMode.Create);

                // Copy image file to the server
                await Electronic_Products.ImageFile.CopyToAsync(filestream);

                // Create a new product
                var newProduct = new Electronic_Product
                {
                    Product_Name = Electronic_Products.Product_Name,
                    Product_Description = Electronic_Products.Product_Description,
                    Product_Price = Electronic_Products.Product_Price,
                    Product_Quantity = Electronic_Products.Product_Quantity,
                    Battery_capacity = Electronic_Products.Battery_capacity,
                    Brand = Electronic_Products.Brand,
                    Operating_System = Electronic_Products.Operating_System,
                    RAM = Electronic_Products.RAM,
                    ROM = Electronic_Products.ROM,
                    Ratings = Electronic_Products.Ratings,
                    Seller_Id = sellerId.Value,  // Assign SellerId from session
                    Seller_Name = Electronic_Products.Seller_Name,
                    ImagePath = $"Upload/{filename}"
                };

                // Add the product to the database
                _context.Electronics.Add(newProduct);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Seller/SellerProductDisplay");
            }

            return Page(); // If no image is uploaded, return to the same page
        }
    }
}

