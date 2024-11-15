using E_commerce.Database.context;
using E_commerce.Database.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Database
{
    public class CustomerViewPageModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public CustomerViewPageModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }

        public List<Electronic_Product> Productlist { get; set; }
        public List<Review> Reviewlist { get; set; }

        public void OnGet(int? Product_Id)
        {
            // Get the list of products
            Productlist = context.Electronics.ToList();

            // Get all reviews
            Reviewlist = context.Reviews.ToList();
        }
    }
}
