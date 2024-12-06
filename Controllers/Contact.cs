using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthSystem.Controllers
{
    [Route("contact")]
    public class Contact : Controller
    {
        private readonly ILogger<Contact> _logger;

        public Contact(ILogger<Contact> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreatePost()
        {
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost("edit/{id}")]
        public IActionResult EditPost(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteConfirmation(int id)
        {
            ViewData["ContactId"] = id;
            return View();
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
