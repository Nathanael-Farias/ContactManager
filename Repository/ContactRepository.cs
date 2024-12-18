using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;
using AuthSystem.Data;

namespace AuthSystem.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ContactModel> AddContactAsync(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ContactModel>> GetAllContactsAsync(int userId)
        {
            return await _context.Contacts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<ContactModel> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<ContactModel> UpdateContactAsync(ContactModel contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
        
    }
}
