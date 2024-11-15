using E_commerce.Database.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace E_commerce.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //[BindProperty]
        //public IFormFile ImageFile { get; set; } //property
        //public readonly IWebHostEnvironment _environment;
        //public IndexModel(IWebHostEnvironment _env)  //refrence
        //{
        //    _environment = _env;
        //}


        public void OnGet()
        {
            //Username=HttpContext.Session.SetString("Username", "Thejaswini");
           

        }
    }
}
