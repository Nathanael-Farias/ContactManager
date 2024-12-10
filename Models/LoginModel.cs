using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "")]
        public string Login { get; set; }

        [Required(ErrorMessage = "")]
              public string Password { get; set; }
    }
}
