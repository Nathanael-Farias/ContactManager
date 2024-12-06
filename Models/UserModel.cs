using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Enums;

namespace AuthSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public EnumProfile Profile {get; set;}
        public string Password { get; set; }
        public DateTime RegistrationDate {get; set;}
        public DateTime? ModificationDate {get; set;}
    
    }
}