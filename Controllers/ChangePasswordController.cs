using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Helper;
using AuthSystem.Models;
using AuthSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthSystem.Controllers
{
    [Route("[controller]")]
    public class ChangePasswordController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISection _section;


        public ChangePasswordController(IUserRepository userRepository, ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePasswordModel)
        {
            try
            {
                UserModel userLogged = _section.FindUserSection();
                changePasswordModel.Id = userLogged.Id;

                if (ModelState.IsValid)
                {
                    var updatedUser = _userRepository.ChangePasswordAsync(changePasswordModel).Result; // Wait for the async method
                    TempData["SuccessMessage"] = "Password successfully changed!";
                    return View("Index", changePasswordModel);
                }
                return View("Index", changePasswordModel);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "We couldn't change your password. Please check your information.";
                return View("Index", changePasswordModel);
            }
        }

        
    }
}