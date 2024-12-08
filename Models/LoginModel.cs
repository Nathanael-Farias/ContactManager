using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class LoginModel
    {
        
        [Display(Name = "Username")]
        public string Login { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
