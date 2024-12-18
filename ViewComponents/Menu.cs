using System.Text.Json;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            string userSection = HttpContext.Session.GetString("UserLoggedSection");

            if(string.IsNullOrEmpty(userSection)) return null;

            UserModel user = JsonSerializer.Deserialize<UserModel>(userSection);
            return View(user);
        }
    }
}