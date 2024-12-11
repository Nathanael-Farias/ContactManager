using System;
using AuthSystem.Enums;
using AuthSystem.Helper;

namespace AuthSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public EnumProfile Profile { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

      public bool PasswordIsValid(string password)
        {
            
            return Password == password.GenerateHash();
        }
        public void SetHashPassword()
        {

            Password = Password.GenerateHash();

        }
        public string GenerateNewPassword()
        {

            string newPassword = Guid.NewGuid().ToString().Substring(0,8);
            Password = newPassword.GenerateHash();
            return newPassword;

        }
    }
}
