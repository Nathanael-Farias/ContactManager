using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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