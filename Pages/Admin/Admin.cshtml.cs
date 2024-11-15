using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class AdminModel : PageModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {

        //        return RedirectToPage("/Admin/AdminSellerApprovalPage");
        //    }
        //    return RedirectToPage("Admin");
        //}
    }
}

