using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid ) 
                {
                    

                   return RedirectToAction("Index", "User"); 
                        
                       
                    

                    
                   
                }
                
                return View("Index");
            }
            catch (Exception error)
            {
                
                TempData["ErrorMessage"] = $"An error occurred: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
