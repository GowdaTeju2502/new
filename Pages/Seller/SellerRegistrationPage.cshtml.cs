using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using E_commerce.Database;
using E_commerce.Database.context;
using Microsoft.EntityFrameworkCore;


namespace E_commerce.Database.Entity
{
    public class SellerRegistrationModel : PageModel
    {
        public readonly ApplicationDbContext context;
        [BindProperty]

        public Seller Sellers { get; set; }

        public SellerRegistrationModel(ApplicationDbContext dbcontext)  //refrence
        {
            context = dbcontext;  //storing
        }
        public void OnGet()
        {
            //PendingSellers = context.Sellers.Where(s => s.Status == "Pending").ToList() ?? new List<Seller>();
        }
        public IActionResult OnPost()
        {
            var name = new Seller()
            {
                Seller_Address = Sellers.Seller_Address,
                Seller_ConfirmPassword = Sellers.Seller_ConfirmPassword,
                Seller_Contact = Sellers.Seller_Contact,
                Seller_District = Sellers.Seller_District,
                Seller_DOB = Sellers.Seller_DOB,
                Seller_Email = Sellers.Seller_Email,
                Seller_Gender = Sellers.Seller_Gender,
                Seller_Id = Sellers.Seller_Id,
                //Seller_isactive = Sellers.Seller_isactive,
                Seller_Name = Sellers.Seller_Name,
                Seller_Password = Sellers.Seller_Password,
                Seller_Pincode = Sellers.Seller_Pincode,
                Seller_State = Sellers.Seller_State,
            };
            context.Sellers.Add(name);
            context.SaveChanges();
            if (ModelState.IsValid)
            {
               
                return RedirectToPage("/Seller/SellerWaitingPage");
            }
            return RedirectToPage("/Seller/SellerRegistrationPage");
        }
    }
}
