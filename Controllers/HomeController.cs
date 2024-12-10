using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models;
using AuthSystem.Filters;

namespace AuthSystem.Controllers;


[LoggedUserPage]
public class HomeController : Controller
{


    public IActionResult Index()
    {
        HomeModel home = new HomeModel();
        home.Nome = "Nathanael";
        home.Email = "nathanael@gmail";
        return View(home);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
