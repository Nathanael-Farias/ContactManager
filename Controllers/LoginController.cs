using AuthSystem.Models;
using AuthSystem.Repository;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
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
