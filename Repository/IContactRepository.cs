using AuthSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthSystem.Repository
{
    public interface IContactRepository
    {
        Task<ContactModel> AddContactAsync(ContactModel contact);
        Task<IEnumerable<ContactModel>> GetAllContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int id);
        Task<ContactModel> UpdateContactAsync(ContactModel contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
