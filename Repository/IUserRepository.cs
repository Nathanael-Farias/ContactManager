using System.Collections.Generic;
using System.Threading.Tasks;
using AuthSystem.Models;

namespace AuthSystem.Repository
{
    public interface IUserRepository
    {

        UserModel SearchByLogin(string login);
        UserModel SearchByEmailAndLogin(string email, string login);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}
