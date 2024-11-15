using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce.Database.context;
using E_commerce.Database.Entity;
using System.Linq;
using E_commerce.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Database.Entity
{
    public class AdminSellerApprovalPageModel : PageModel
    {
        public readonly ApplicationDbContext context;
        public AdminSellerApprovalPageModel(ApplicationDbContext dbcontext)  //refrence
        {
            context = dbcontext;  //storing
        }
        public List<Seller> PendingSellers {get;set;} = new List<Seller>();
        public void OnGet()
        {
            PendingSellers = context.Sellers.Where(s => !s.IsApproved).ToList();
        }
        public IActionResult OnPostApprove(int sellerId)
        {
            //Console.WriteLine($"Approving seller with ID: {sellerId}");
            var seller = context.Sellers.Find(sellerId);
            if (seller != null)
            {
                seller.IsApproved = true;
                context.SaveChanges();
                return RedirectToPage("/Seller/SellerProducts");
            }
            //return NotFound();
            return RedirectToPage();
        }
        public IActionResult OnPostDeny(int sellerId)
        {
            var seller = context.Sellers.Find(sellerId);
            if (seller != null)
            {
                context.Sellers.Remove(seller);
                context.SaveChanges();
                return RedirectToPage("/Seller/SellerRegistrationPage");
            }
            return NotFound();
        }
    }
}
