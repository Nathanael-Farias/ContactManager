using AuthSystem.Models;

namespace AuthSystem.Helper
{
    public interface ISection
    {
        void CreateUserSection(UserModel user);
        void RemoveUserSection();
        UserModel FindUserSection();
    }
}