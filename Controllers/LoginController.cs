using AuthSystem.Helper;
using AuthSystem.Models;
using AuthSystem.Repository;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly ISection _section;

    public LoginController(IUserRepository userRepository, ISection section)
    {
        _userRepository = userRepository;
        _section = section;
    }

    public IActionResult Index()
    {
             if (_section.FindUserSection() != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

    }

    public IActionResult Exit()
    {
        _section.RemoveUserSection();
        return RedirectToAction("Index","Login");
    }



    [HttpPost]
   public IActionResult Enter(LoginModel loginModel)
{
    if (ModelState.IsValid)
    {
        UserModel user = _userRepository.SearchByLogin(loginModel.Login);

        if (user != null)
        {
            if (user.PasswordIsValid(loginModel.Password))
            {
                
                _section.CreateUserSection(user);
                return RedirectToAction("Index", "Home");
            }

            
            TempData["ErrorMessage"] = "Incorrect password.";
        }
        else
        {
            
            TempData["ErrorMessage"] = "Invalid username.";
        }
    }
    else
    {
        
        TempData["ErrorMessage"] = "Please provide valid credentials.";
    }

    return View("Index");
}


}
