using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class ResetPasswordModel
    {
    [Required(ErrorMessage = "Login is required.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }
    }
}