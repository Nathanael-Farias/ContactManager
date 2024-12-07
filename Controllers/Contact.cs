using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models;
using AuthSystem.Repository;

namespace AuthSystem.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
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
                        return NotFound();
                    }

                    await _contactRepository.DeleteContactAsync(id);

                    
                    TempData["SuccessMessage"] = "Contato deletado com sucesso!";

                    
                    return RedirectToAction("Index");
                }
    }
}





    
