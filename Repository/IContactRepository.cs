using AuthSystem.Models;

namespace AuthSystem.Repository
{
    public interface IContactRepository
    {
        Task<ContactModel> AddContactAsync(ContactModel contact);
        Task<IEnumerable<ContactModel>> GetAllContactsAsync(int userId);
        Task<ContactModel> GetContactByIdAsync(int id);
        Task<ContactModel> UpdateContactAsync(ContactModel contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
