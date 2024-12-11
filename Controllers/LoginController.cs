using AuthSystem.Helper;
using AuthSystem.Models;
using AuthSystem.Repository;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly ISection _section;
    private readonly IEmail _email;

    public LoginController(IUserRepository userRepository, ISection section, IEmail email)
    {
        _userRepository = userRepository;
        _section = section;
        _email = email;
    }

    public IActionResult Index()
    {
             if (_section.FindUserSection() != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

    }

    public IActionResult ResetPassword()
    {
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
   [HttpPost]
    public IActionResult SendResetPasswordLink(ResetPasswordModel resetPasswordModel)
    {
        if (ModelState.IsValid)
        {
            UserModel user = _userRepository.SearchByEmailAndLogin(resetPasswordModel.Email, resetPasswordModel.Login);

            if (user != null)
            {


                string newPassword = user.GenerateNewPassword();
                

                string message = $"Your new password is {newPassword}";
                bool emailSend = _email.Send(user.Email, "Contact Manager -new password", message);

                if(emailSend)
                {
                    _userRepository.UpdateUserAsync(user);
                    TempData["SuccessMessage"] = "A new password has been sent to your registered email.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Please provide valid credentials and try again, we cannot send a email to you";
                }
                
                return View("ResetPassword"); 
            }
            else
            {
            
                TempData["ErrorMessage"] = "Invalid username or email.";
            }
        }
        else
        {
            
            TempData["ErrorMessage"] = "Please provide valid credentials.";
        }

        return View("ResetPassword");
    }

}




