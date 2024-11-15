using E_commerce.Database.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Database.Entity
{
    public class SellerProductDisplayModel : PageModel
    {

        private readonly ApplicationDbContext context;//reference

        public SellerProductDisplayModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext;//storing locally........

        }
        public List<Electronic_Product> Productlist
        { get; set; }
        public void OnGet()
        {
            Productlist = context.Electronics.ToList();
        }

    }
}
