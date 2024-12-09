using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required.")]
       
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "Password must contain only letters and numbers.")]
        public string Password { get; set; }
    }
}
