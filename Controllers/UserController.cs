using Microsoft.AspNetCore.Mvc;
using AuthSystem.Repository;
using AuthSystem.Models;
using AuthSystem.Filters;
using System;

namespace AuthSystem.Controllers
{
    [Route("[controller]")]
    [RestrictPageOnlyAdmin]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(UserModel user)
        {
            if (ModelState.IsValid)
            {
                user.RegistrationDate = DateTime.Now;
                user.ModificationDate = DateTime.Now;
                await _userRepository.AddUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user); 
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest("IDs do not match.");
            }

            if (ModelState.IsValid)
            {
                var existingUser = await _userRepository.GetUserByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    user.Password = existingUser.Password;
                }

                existingUser.Nome = user.Nome;
                existingUser.Email = user.Email;
                existingUser.Login = user.Login;
                existingUser.Profile = user.Profile;
                existingUser.Password = user.Password;

                await _userRepository.UpdateUserAsync(existingUser);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); 
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUserAsync(id);

            return RedirectToAction("Index");
        }

     
    }
}