using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;
using AuthSystem.Data;

namespace AuthSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            user.RegistrationDate = DateTime.UtcNow;
            user.ModificationDate = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return null; 
            }

            existingUser.Nome = user.Nome;
            existingUser.Login = user.Login;
            existingUser.Email = user.Email;
            existingUser.Profile = user.Profile;
            existingUser.Password = user.Password;
            existingUser.ModificationDate = DateTime.UtcNow;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false; 
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking() 
                .Where(user => user.Id == id)
                .Select(user => new UserModel
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Login = user.Login,
                    Email = user.Email,
                    Profile = user.Profile,
                    Password = user.Password,
                    RegistrationDate = user.RegistrationDate,
                    ModificationDate = user.ModificationDate
                })
                .FirstOrDefaultAsync();
        }
    }
}
