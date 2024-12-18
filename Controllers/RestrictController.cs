using AuthSystem.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{

    [LoggedUserPage]
    public class RestrictController : Controller
    {
        
                
        public IActionResult Index()
        {
            return View();
        }

       
    }
}