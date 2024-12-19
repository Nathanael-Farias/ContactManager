using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models;
using AuthSystem.Repository;
using AuthSystem.Filters;
using AuthSystem.Helper;

namespace AuthSystem.Controllers
{
    [Route("contact")]
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISection _section;

        public ContactController(IContactRepository contactRepository, ISection section)
        {
            _contactRepository = contactRepository;
            _section = section;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            UserModel userLogged = _section.FindUserSection();
            var contacts = await _contactRepository.GetAllContactsAsync(userLogged.Id);
            return View(contacts);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                UserModel userLogged = _section.FindUserSection();
                contact.UserId = userLogged.Id;
                await _contactRepository.AddContactAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

                [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            
            return View("Edit", contact);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ContactModel contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            var existingContact = await _contactRepository.GetContactByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            UserModel userLogged = _section.FindUserSection();
            contact.UserId = userLogged.Id;

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;

            await _contactRepository.UpdateContactAsync(existingContact);

            
            TempData["SuccessMessage"] = "Contact updated successfully!";

            
            return RedirectToAction("Index");
        }


        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            ViewData["Contact"] = contact;
            return View(contact);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = "Contact not found.";
                return RedirectToAction("Index");
            }

            await _contactRepository.DeleteContactAsync(id);

            TempData["SuccessMessage"] = "Contact deleted.";
            
            return RedirectToAction("Index");
        }

    }
}





    
