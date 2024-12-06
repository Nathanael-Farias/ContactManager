using Microsoft.AspNetCore.Mvc;
using AuthSystem.Data;
using System.Linq;

namespace AuthSystem.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList(); 
            return View(users);
        }

        
    }
}
